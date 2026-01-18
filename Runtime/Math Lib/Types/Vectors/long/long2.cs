using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(long))]
    [DebuggerTypeProxy(typeof(long2.DebuggerProxy))]
    unsafe public struct long2 : IEquatable<long2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;

            public DebuggerProxy(long2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] public long x;
        [FieldOffset(8)] public long y;


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


        #region Shuffle
		public readonly long4 xxxx => (long4)((ulong2)this).xxxx;
        public readonly long4 xxxy => (long4)((ulong2)this).xxxy;
        public readonly long4 xxyx => (long4)((ulong2)this).xxyx;
        public readonly long4 xxyy => (long4)((ulong2)this).xxyy;
        public readonly long4 xyxx => (long4)((ulong2)this).xyxx;
		public readonly long4 xyxy => (long4)((ulong2)this).xyxy;
		public readonly long4 xyyx => (long4)((ulong2)this).xyyx;
		public readonly long4 xyyy => (long4)((ulong2)this).xyyy;
		public readonly long4 yxxx => (long4)((ulong2)this).yxxx;
        public readonly long4 yxxy => (long4)((ulong2)this).yxxy;
		public readonly long4 yxyx => (long4)((ulong2)this).yxyx;
        public readonly long4 yxyy => (long4)((ulong2)this).yxyy;
		public readonly long4 yyxx => (long4)((ulong2)this).yyxx;
        public readonly long4 yyxy => (long4)((ulong2)this).yyxy;
		public readonly long4 yyyx => (long4)((ulong2)this).yyyx;
        public readonly long4 yyyy => (long4)((ulong2)this).yyyy;

		public readonly long3 xxx => (long3)((ulong2)this).xxx;
        public readonly long3 xxy => (long3)((ulong2)this).xxy;
		public readonly long3 xyx => (long3)((ulong2)this).xyx;
        public readonly long3 xyy => (long3)((ulong2)this).xyy;
		public readonly long3 yxx => (long3)((ulong2)this).yxx;
        public readonly long3 yxy => (long3)((ulong2)this).yxy;
		public readonly long3 yyx => (long3)((ulong2)this).yyx;
        public readonly long3 yyy => (long3)((ulong2)this).yyy;

		public readonly long2 xx => (long2)((ulong2)this).xx;
		public          long2 yx { readonly get => (long2)((ulong2)this).yx;  set { ulong2 _this = (ulong2)this; _this.yx = (ulong2)value; this = (long2)_this; } }
        public readonly long2 yy => (long2)((ulong2)this).yy;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(long2 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(v128 input) => RegisterConversion.ToAbstraction128<long2>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(long input) => new long2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(ulong2 input) => *(long2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(uint2 input) => (long2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(int2 input) => (long2)(ulong2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new long2((int)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                 (int)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttps_epi64(RegisterConversion.ToV128(input));
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
                return Xse.cvttpd_epi64(RegisterConversion.ToV128(input));
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
        public static explicit operator half2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtepi64_ph(input, (half)float.PositiveInfinity));
            }
            else
            {
                return (half2)(float2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.cvtepi64_ps(input));
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
                return RegisterConversion.ToDouble2(Xse.cvtepi64_pd(input));
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
        public static long2 operator / (long2 left, byte2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepu8_epi64(right), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, ushort2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepu16_epi64(right), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, uint2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepu32_epi64(RegisterConversion.ToV128(right)), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, sbyte2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepi8_epi64(right), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, short2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepi16_epi64(right), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, int2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right)), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator / (long2 left, long2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.div_epi64(left, right, useFPU: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi64(left, right, useFPU: true);
            }
            else
            {
                return new long2(left.x / right.x, left.y / right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, byte2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu8_epi64(right), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, ushort2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu16_epi64(right), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, uint2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu32_epi64(RegisterConversion.ToV128(right)), useFPU: false, bIsDbl: false, bNonNegative: true);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, sbyte2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi8_epi64(right), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, short2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi16_epi64(right), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, int2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right)), useFPU: false, bIsDbl: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator % (long2 left, long2 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.rem_epi64(left, right, useFPU: false);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi64(left, right, useFPU: true);
            }
            else
            {
                return new long2(left.x % right.x, left.y % right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long left, long2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator * (long2 left, long right)
        {
            if (constexpr.IS_CONST(right))
            {
                 return new long2(left.x * right, left.y * right);
            }
            else
            {
                return left * (long2)right;
            }
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

            return left / (long2)right;
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

            return left % (long2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator & (long2 left, long2 right) => (long2)((ulong2)left & (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator | (long2 left, long2 right) => (long2)((ulong2)left | (ulong2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 operator ^ (long2 left, long2 right) => (long2)((ulong2)left ^ (ulong2)right);


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
                return Xse.srai_epi64(x, n, inRange: true);
            }
            else
            {
                return new long2(x.x >> n, x.y >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (long2 left, long2 right) => (ulong2)left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (long2 left, long2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmplt_epi64(left, right)));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (long2 left, long2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmpgt_epi64(left, right)));
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (long2 left, long2 right) => (ulong2)left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (long2 left, long2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse64(Xse.cmpgt_epi64(left, right)));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (long2 left, long2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse64(Xse.cmplt_epi64(left, right)));
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2 other) => ((ulong2)this).Equals((ulong2)other);

        public override readonly bool Equals(object obj) => obj is long2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ulong2)this).GetHashCode();


        public override readonly string ToString() => $"long2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}