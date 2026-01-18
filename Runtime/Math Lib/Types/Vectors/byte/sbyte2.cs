using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

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
            this = (sbyte2)new byte2((byte)x, (byte)y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            this = (sbyte2)new byte2((byte)xy);
        }


        #region Shuffle
		public readonly sbyte4 xxxx => (sbyte4)((byte2)this).xxxx;
        public readonly sbyte4 xxxy => (sbyte4)((byte2)this).xxxy;
        public readonly sbyte4 xxyx => (sbyte4)((byte2)this).xxyx;
        public readonly sbyte4 xxyy => (sbyte4)((byte2)this).xxyy;
        public readonly sbyte4 xyxx => (sbyte4)((byte2)this).xyxx;
		public readonly sbyte4 xyxy => (sbyte4)((byte2)this).xyxy;
		public readonly sbyte4 xyyx => (sbyte4)((byte2)this).xyyx;
		public readonly sbyte4 xyyy => (sbyte4)((byte2)this).xyyy;
		public readonly sbyte4 yxxx => (sbyte4)((byte2)this).yxxx;
        public readonly sbyte4 yxxy => (sbyte4)((byte2)this).yxxy;
		public readonly sbyte4 yxyx => (sbyte4)((byte2)this).yxyx;
        public readonly sbyte4 yxyy => (sbyte4)((byte2)this).yxyy;
		public readonly sbyte4 yyxx => (sbyte4)((byte2)this).yyxx;
        public readonly sbyte4 yyxy => (sbyte4)((byte2)this).yyxy;
		public readonly sbyte4 yyyx => (sbyte4)((byte2)this).yyyx;
        public readonly sbyte4 yyyy => (sbyte4)((byte2)this).yyyy;

		public readonly sbyte3 xxx => (sbyte3)((byte2)this).xxx;
        public readonly sbyte3 xxy => (sbyte3)((byte2)this).xxy;
		public readonly sbyte3 xyx => (sbyte3)((byte2)this).xyx;
        public readonly sbyte3 xyy => (sbyte3)((byte2)this).xyy;
		public readonly sbyte3 yxx => (sbyte3)((byte2)this).yxx;
        public readonly sbyte3 yxy => (sbyte3)((byte2)this).yxy;
		public readonly sbyte3 yyx => (sbyte3)((byte2)this).yyx;
        public readonly sbyte3 yyy => (sbyte3)((byte2)this).yyy;

		public readonly sbyte2 xx => (sbyte2)((byte2)this).xx;
        public          sbyte2 xy { readonly get => (sbyte2)((byte2)this).xy;  set { byte2 _this = (byte2)this; _this.xy = (byte2)value; this = (sbyte2)_this; } }
		public          sbyte2 yx { readonly get => (sbyte2)((byte2)this).yx;  set { byte2 _this = (byte2)this; _this.yx = (byte2)value; this = (sbyte2)_this; } }
        public readonly sbyte2 yy => (sbyte2)((byte2)this).yy;
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input) => RegisterConversion.ToAbstraction128<sbyte2>(input);


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
        public static explicit operator sbyte2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new sbyte2((sbyte)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true));
            }
        }

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
            if (BurstArchitecture.IsSIMDSupported)
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
        public static implicit operator half2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi8_ph(input, elements: 2));
            }
            else
            {
                return (half2)(float2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
        public static sbyte2 operator * (sbyte left, sbyte2 right) => right * left;


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
        public static sbyte2 operator & (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left & (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left | (byte2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 left, sbyte2 right) => (sbyte2)((byte2)left ^ (byte2)right);


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
        public static bool2 operator == (sbyte2 left, sbyte2 right) => (byte2)left == (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmpgt_epi8(left, right));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (sbyte2 left, sbyte2 right) => (byte2)left != (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (sbyte2 left, sbyte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse8(Xse.cmpgt_epi8(left, right));

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
            if (BurstArchitecture.IsSIMDSupported)
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
        public readonly bool Equals(sbyte2 other) => ((byte2)this).Equals((byte2)other);

        public override readonly bool Equals(object obj) => obj is sbyte2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((byte2)this).GetHashCode();


        public override readonly string ToString() => $"sbyte2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}