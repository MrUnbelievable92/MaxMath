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
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(sbyte))] 
    [DebuggerTypeProxy(typeof(sbyte2.DebuggerProxy))]
    unsafe public struct sbyte2 : IEquatable<sbyte2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public sbyte x;
            public sbyte y;

            public DebuggerProxy(sbyte2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;


        public static sbyte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte x, sbyte y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y))
                {
                    this = Sse2.cvtsi32_si128(bitfield(x, y));
                }
                else
                {
                    this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, y, x);
                }
            }
            else
            {
                this.x = x;
                this.y = y;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(xy))
                {
                    this = Sse2.cvtsi32_si128(bitfield(xy, xy));
                }
                else
                {
                    this = Sse2.set1_epi8(xy);
                }
            }
            else
            {
                this.x = this.y = xy;
            }
        }

        
        #region Shuffle
		public readonly sbyte4 xxxx
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
                    return new sbyte4(x, x, x, x);
                }
            }
        }
        public readonly sbyte4 xxxy
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
                    return new sbyte4(x, x, x, y);
                }
            }
        }
        public readonly sbyte4 xxyx
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
                    return new sbyte4(x, x, y, x);
                }
            }
        }
        public readonly sbyte4 xxyy
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
					return new sbyte4(x, x, y, y);
				}
			}
		}
        public readonly sbyte4 xyxx
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
                    return new sbyte4(x, y, x, x);
                }
            }
        }
		public readonly sbyte4 xyxy
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
					return new sbyte4(x, y, x, y);
				}
			}
		}
		public readonly sbyte4 xyyx
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
                    return new sbyte4(x, y, y, x);
                }
            }
        }
		public readonly sbyte4 xyyy
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
                    return new sbyte4(x, y, y, y);
                }
            }
        }
		public readonly sbyte4 yxxx
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
                    return new sbyte4(y, x, x, x);
                }
            }
        }
        public readonly sbyte4 yxxy
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
                    return new sbyte4(y, x, x, y);
                }
            }
        }
		public readonly sbyte4 yxyx
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
                    return new sbyte4(y, x, y, x);
                }
            }
        }
        public readonly sbyte4 yxyy
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
                    return new sbyte4(y, x, y, y);
                }
            }
        }
		public readonly sbyte4 yyxx
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
                    return new sbyte4(y, y, x, x);
                }
            }
        }
        public readonly sbyte4 yyxy
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
                    return new sbyte4(y, y, x, y);
                }
            }
        }
		public readonly sbyte4 yyyx
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
                    return new sbyte4(y, y, y, x);
                }
            }
        }
        public readonly sbyte4 yyyy
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
                    return new sbyte4(y, y, y, y);
                }
            }
        }

		public readonly sbyte3 xxx
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
                    return new sbyte3(x, x, x);
                }
            }
        }
        public readonly sbyte3 xxy
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
                    return new sbyte3(x, x, y);
                }
            }
        }
		public readonly sbyte3 xyx
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
                    return new sbyte3(x, y, x);
                }
            }
        }
        public readonly sbyte3 xyy
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
                    return new sbyte3(x, y, y);
                }
            }
        }
		public readonly sbyte3 yxx
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
                    return new sbyte3(y, x, x);
                }
            }
        }
        public readonly sbyte3 yxy
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
                    return new sbyte3(y, x, y);
                }
            }
        }
		public readonly sbyte3 yyx
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
                    return new sbyte3(y, y, x);
                }
            }
        }
        public readonly sbyte3 yyy
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
                    return new sbyte3(y, y, y);
                }
            }
        }

		public readonly sbyte2 xx
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
                    return new sbyte2(x, x);
                }
            }
        }
        public          sbyte2 xy
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
                    return new sbyte2(x, y);
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
		public          sbyte2 yx
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
                    return new sbyte2(y, x);
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
        
        public readonly sbyte2 yy
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
                    return new sbyte2(y, y);
                }
            }
        }
		#endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                v128* dummyPtr = &result;
            }

            result.SByte0 = input.x;
            result.SByte1 = input.y;
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input) => new sbyte2 { x = input.SByte0, y = input.SByte1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(sbyte input) => new sbyte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(sbyte2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(int2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi64_epi8(input);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ulong2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi64_epi8(input);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(half2 input) => (sbyte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(float2 input) => (sbyte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(double2 input) => (sbyte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.cvtepi8_epi32(input));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtepi8_epi32(input));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi8_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(sbyte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(Xse.cvtepi8_ps(input));
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.cvtepi8_pd(input));
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
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    return (sbyte)Xse.extract_epi8(this, (byte)index);
                }
                else
                {
                    sbyte2 onStack = this;

                    return *((sbyte*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi8(this, (byte)value, (byte)index);
                }
                else
                {
                    sbyte2 onStack = this;
                    *((sbyte*)&onStack + index) = value;

                    this = onStack;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator + (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x + right.x), (sbyte)(left.y + right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x - right.x), (sbyte)(left.y - right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mullo_epi8(left, right, 2);
            }
            else
            {
                return new sbyte2((sbyte)(left.x * right.x), (sbyte)(left.y * right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epi8(left, right, 2);
            }
            else
            {
                return new sbyte2((sbyte)(left.x % right.x), (sbyte)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte left, sbyte2 right) => right * left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mullo_epi8(left, right, 2);
                }
            }

            return left * (sbyte2)right;
        } 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi8(left, right, 2);
                }
            }
                
            return left / (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi8(left, right, 2);
                }
            }
                
            return left % (sbyte2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x & right.x), (sbyte)(left.y & right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x | right.x), (sbyte)(left.y | right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x ^ right.x), (sbyte)(left.y ^ right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte2((sbyte)(x.x - 1), (sbyte)(x.y - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ~ (sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new sbyte2((sbyte)~x.x, (sbyte)~x.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator << (sbyte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi8(x, n);
            }
            else
            {
                return new sbyte2((sbyte)(x.x << n), (sbyte)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator >> (sbyte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi8(x, n, 2);
            }
            else
            {
                return new sbyte2((sbyte)(x.x >> n), (sbyte)(x.y >> n));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(Sse2.cmpeq_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmplt_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(Sse2.cmpgt_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse8(Sse2.cmpeq_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse8(Sse2.cmpgt_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (sbyte2 left, sbyte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse8(Xse.cmplt_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte2 other)
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

        public override readonly bool Equals(object obj) => obj is sbyte2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse.IsSseSupported)
            {
                return ((v128)this).UShort0;
            }
            else
            {
                sbyte2 temp = this;

                return *(ushort*)&temp;
            }
        }


        public override readonly string ToString() => $"sbyte2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}