using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(short))]
    [DebuggerTypeProxy(typeof(short2.DebuggerProxy))]
    unsafe public struct short2 : IEquatable<short2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public short x;
            public short y;

            public DebuggerProxy(short2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;


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


        #region Shuffle
		public readonly short4 xxxx => (short4)((ushort2)this).xxxx;
        public readonly short4 xxxy => (short4)((ushort2)this).xxxy;
        public readonly short4 xxyx => (short4)((ushort2)this).xxyx;
        public readonly short4 xxyy => (short4)((ushort2)this).xxyy;
        public readonly short4 xyxx => (short4)((ushort2)this).xyxx;
		public readonly short4 xyxy => (short4)((ushort2)this).xyxy;
		public readonly short4 xyyx => (short4)((ushort2)this).xyyx;
		public readonly short4 xyyy => (short4)((ushort2)this).xyyy;
		public readonly short4 yxxx => (short4)((ushort2)this).yxxx;
        public readonly short4 yxxy => (short4)((ushort2)this).yxxy;
		public readonly short4 yxyx => (short4)((ushort2)this).yxyx;
        public readonly short4 yxyy => (short4)((ushort2)this).yxyy;
		public readonly short4 yyxx => (short4)((ushort2)this).yyxx;
        public readonly short4 yyxy => (short4)((ushort2)this).yyxy;
		public readonly short4 yyyx => (short4)((ushort2)this).yyyx;
        public readonly short4 yyyy => (short4)((ushort2)this).yyyy;

		public readonly short3 xxx => (short3)((ushort2)this).xxx;
        public readonly short3 xxy => (short3)((ushort2)this).xxy;
		public readonly short3 xyx => (short3)((ushort2)this).xyx;
        public readonly short3 xyy => (short3)((ushort2)this).xyy;
		public readonly short3 yxx => (short3)((ushort2)this).yxx;
        public readonly short3 yxy => (short3)((ushort2)this).yxy;
		public readonly short3 yyx => (short3)((ushort2)this).yyx;
        public readonly short3 yyy => (short3)((ushort2)this).yyy;

		public readonly short2 xx => (short2)((ushort2)this).xx;
		public          short2 yx { readonly get => (short2)((ushort2)this).yx;  set { ushort2 _this = (ushort2)this; _this.yx = (ushort2)value; this = (short2)_this; } }
        public readonly short2 yy => (short2)((ushort2)this).yy;
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short2 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = default(v128);
            }

            result.SShort0 = input.x;
            result.SShort1 = input.y;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(v128 input) => new short2 { x = input.SShort0, y = input.SShort1 };


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
        public static explicit operator short2(half2 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new short2((short)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(float2 input) => (short2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(double2 input) => (short2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(short2 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(short2 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(short2 input)
        {
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(short2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(short2 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(short2 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.cvtepi16_pd(input));
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
        public static short2 operator - (short2 left, short2 right) => (short2)((ushort2)left - (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, short2 right) => (short2)((ushort2)left * (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 2);
            }
            else
            {
                return new short2((short)(left.x / right.x), (short)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 2);
            }
            else
            {
                return new short2((short)(left.x % right.x), (short)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short left, short2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, short right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return (v128)((short8)((v128)left) * right);
                }
            }

            return left * (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 2);
                }
            }

            return left / (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 2);
                }
            }

            return left % (short2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, short2 right) => (short2)((ushort2)left & (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, short2 right) => (short2)((ushort2)left | (ushort2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, short2 right) => (short2)((ushort2)left ^ (ushort2)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 x)
        {
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short2((short)(x.x >> n), (short)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (short2 left, short2 right) => (ushort2)left == (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmplt_epi16(left, right));

				return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpgt_epi16(left, right));

				return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (short2 left, short2 right) => (ushort2)left != (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmpgt_epi16(left, right));

				return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (short2 left, short2 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmplt_epi16(left, right));

				return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2 other) => ((ushort2)this).Equals((ushort2)other);

        public override readonly bool Equals(object obj) => obj is short2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ushort2)this).GetHashCode();


        public override readonly string ToString() => $"short2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}