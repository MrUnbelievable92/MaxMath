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
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(long))]
    [DebuggerTypeProxy(typeof(long3.DebuggerProxy))]
    unsafe public struct long3 : IEquatable<long3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;
            public long z;

            public DebuggerProxy(long3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)]  internal long2 _xy;

        [FieldOffset(0)]  public long x;
        [FieldOffset(8)]  public long y;
        [FieldOffset(16)] public long z;


        public static long3 zero => default;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long y, long z)
        {
            this = (long3)new ulong3((ulong)x, (ulong)y, (ulong)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long xyz)
        {
            this = (long3)new ulong3((ulong)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long2 xy, long z)
        {
            this = (long3)new ulong3((ulong2)xy, (ulong)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long2 yz)
        {
            this = (long3)new ulong3((ulong)x, (ulong2)yz);
        }


        #region Shuffle
        public readonly long4 xxxx => (long4)((ulong3)this).xxxx;
        public readonly long4 xxxy => (long4)((ulong3)this).xxxy;
        public readonly long4 xxxz => (long4)((ulong3)this).xxxz;
        public readonly long4 xxyx => (long4)((ulong3)this).xxyx;
        public readonly long4 xxyy => (long4)((ulong3)this).xxyy;
        public readonly long4 xxyz => (long4)((ulong3)this).xxyz;
        public readonly long4 xxzx => (long4)((ulong3)this).xxzx;
        public readonly long4 xxzy => (long4)((ulong3)this).xxzy;
        public readonly long4 xxzz => (long4)((ulong3)this).xxzz;
        public readonly long4 xyxx => (long4)((ulong3)this).xyxx;
		public readonly long4 xyxy => (long4)((ulong3)this).xyxy;
        public readonly long4 xyxz => (long4)((ulong3)this).xyxz;
		public readonly long4 xyyx => (long4)((ulong3)this).xyyx;
		public readonly long4 xyyy => (long4)((ulong3)this).xyyy;
		public readonly long4 xyyz => (long4)((ulong3)this).xyyz;
		public readonly long4 xyzx => (long4)((ulong3)this).xyzx;
        public readonly long4 xyzy => (long4)((ulong3)this).xyzy;
        public readonly long4 xyzz => (long4)((ulong3)this).xyzz;
		public readonly long4 xzxx => (long4)((ulong3)this).xzxx;
        public readonly long4 xzxy => (long4)((ulong3)this).xzxy;
        public readonly long4 xzxz => (long4)((ulong3)this).xzxz;
		public readonly long4 xzyx => (long4)((ulong3)this).xzyx;
        public readonly long4 xzyy => (long4)((ulong3)this).xzyy;
        public readonly long4 xzyz => (long4)((ulong3)this).xzyz;
		public readonly long4 xzzx => (long4)((ulong3)this).xzzx;
        public readonly long4 xzzy => (long4)((ulong3)this).xzzy;
        public readonly long4 xzzz => (long4)((ulong3)this).xzzz;
		public readonly long4 yxxx => (long4)((ulong3)this).yxxx;
        public readonly long4 yxxy => (long4)((ulong3)this).yxxy;
        public readonly long4 yxxz => (long4)((ulong3)this).yxxz;
		public readonly long4 yxyx => (long4)((ulong3)this).yxyx;
        public readonly long4 yxyy => (long4)((ulong3)this).yxyy;
        public readonly long4 yxyz => (long4)((ulong3)this).yxyz;
		public readonly long4 yxzx => (long4)((ulong3)this).yxzx;
        public readonly long4 yxzy => (long4)((ulong3)this).yxzy;
        public readonly long4 yxzz => (long4)((ulong3)this).yxzz;
		public readonly long4 yyxx => (long4)((ulong3)this).yyxx;
        public readonly long4 yyxy => (long4)((ulong3)this).yyxy;
        public readonly long4 yyxz => (long4)((ulong3)this).yyxz;
		public readonly long4 yyyx => (long4)((ulong3)this).yyyx;
        public readonly long4 yyyy => (long4)((ulong3)this).yyyy;
        public readonly long4 yyyz => (long4)((ulong3)this).yyyz;
		public readonly long4 yyzx => (long4)((ulong3)this).yyzx;
        public readonly long4 yyzy => (long4)((ulong3)this).yyzy;
        public readonly long4 yyzz => (long4)((ulong3)this).yyzz;
		public readonly long4 yzxx => (long4)((ulong3)this).yzxx;
        public readonly long4 yzxy => (long4)((ulong3)this).yzxy;
        public readonly long4 yzxz => (long4)((ulong3)this).yzxz;
		public readonly long4 yzyx => (long4)((ulong3)this).yzyx;
        public readonly long4 yzyy => (long4)((ulong3)this).yzyy;
        public readonly long4 yzyz => (long4)((ulong3)this).yzyz;
		public readonly long4 yzzx => (long4)((ulong3)this).yzzx;
        public readonly long4 yzzy => (long4)((ulong3)this).yzzy;
        public readonly long4 yzzz => (long4)((ulong3)this).yzzz;
		public readonly long4 zxxx => (long4)((ulong3)this).zxxx;
        public readonly long4 zxxy => (long4)((ulong3)this).zxxy;
        public readonly long4 zxxz => (long4)((ulong3)this).zxxz;
		public readonly long4 zxyx => (long4)((ulong3)this).zxyx;
        public readonly long4 zxyy => (long4)((ulong3)this).zxyy;
        public readonly long4 zxyz => (long4)((ulong3)this).zxyz;
		public readonly long4 zxzx => (long4)((ulong3)this).zxzx;
        public readonly long4 zxzy => (long4)((ulong3)this).zxzy;
        public readonly long4 zxzz => (long4)((ulong3)this).zxzz;
		public readonly long4 zyxx => (long4)((ulong3)this).zyxx;
        public readonly long4 zyxy => (long4)((ulong3)this).zyxy;
        public readonly long4 zyxz => (long4)((ulong3)this).zyxz;
		public readonly long4 zyyx => (long4)((ulong3)this).zyyx;
        public readonly long4 zyyy => (long4)((ulong3)this).zyyy;
        public readonly long4 zyyz => (long4)((ulong3)this).zyyz;
		public readonly long4 zyzx => (long4)((ulong3)this).zyzx;
        public readonly long4 zyzy => (long4)((ulong3)this).zyzy;
        public readonly long4 zyzz => (long4)((ulong3)this).zyzz;
		public readonly long4 zzxx => (long4)((ulong3)this).zzxx;
        public readonly long4 zzxy => (long4)((ulong3)this).zzxy;
        public readonly long4 zzxz => (long4)((ulong3)this).zzxz;
		public readonly long4 zzyx => (long4)((ulong3)this).zzyx;
        public readonly long4 zzyy => (long4)((ulong3)this).zzyy;
        public readonly long4 zzyz => (long4)((ulong3)this).zzyz;
		public readonly long4 zzzx => (long4)((ulong3)this).zzzx;
        public readonly long4 zzzy => (long4)((ulong3)this).zzzy;
        public readonly long4 zzzz => (long4)((ulong3)this).zzzz;

		public readonly long3 xxx => (long3)((ulong3)this).xxx;
        public readonly long3 xxy => (long3)((ulong3)this).xxy;
        public readonly long3 xxz => (long3)((ulong3)this).xxz;
		public readonly long3 xyx => (long3)((ulong3)this).xyx;
        public readonly long3 xyy => (long3)((ulong3)this).xyy;
		public readonly long3 xzx => (long3)((ulong3)this).xzx;
        public          long3 xzy { readonly get => (long3)((ulong3)this).xzy;  set { ulong3 _this = (ulong3)this; _this.xzy = (ulong3)value; this = (long3)_this; } }
        public readonly long3 xzz => (long3)((ulong3)this).xzz;
		public readonly long3 yxx => (long3)((ulong3)this).yxx;
        public readonly long3 yxy => (long3)((ulong3)this).yxy;
        public          long3 yxz { readonly get => (long3)((ulong3)this).yxz;  set { ulong3 _this = (ulong3)this; _this.yxz = (ulong3)value; this = (long3)_this; } }
		public readonly long3 yyx => (long3)((ulong3)this).yyx;
        public readonly long3 yyy => (long3)((ulong3)this).yyy;
        public readonly long3 yyz => (long3)((ulong3)this).yyz;
		public          long3 yzx { readonly get => (long3)((ulong3)this).yzx;  set { ulong3 _this = (ulong3)this; _this.yzx = (ulong3)value; this = (long3)_this; } }
        public readonly long3 yzy => (long3)((ulong3)this).yzy;
        public readonly long3 yzz => (long3)((ulong3)this).yzz;
		public readonly long3 zxx => (long3)((ulong3)this).zxx;
        public          long3 zxy { readonly get => (long3)((ulong3)this).zxy;  set { ulong3 _this = (ulong3)this; _this.zxy = (ulong3)value; this = (long3)_this; } }
        public readonly long3 zxz => (long3)((ulong3)this).zxz;
		public          long3 zyx { readonly get => (long3)((ulong3)this).zyx;  set { ulong3 _this = (ulong3)this; _this.zyx = (ulong3)value; this = (long3)_this; } }
        public readonly long3 zyy => (long3)((ulong3)this).zyy;
        public readonly long3 zyz => (long3)((ulong3)this).zyz;
		public readonly long3 zzx => (long3)((ulong3)this).zzx;
        public readonly long3 zzy => (long3)((ulong3)this).zzy;
        public readonly long3 zzz => (long3)((ulong3)this).zzz;

		public readonly long2 xx => (long2)((ulong3)this).xx;
        public          long2 xy { readonly get => (long2)((ulong3)this).xy;  set { ulong3 _this = (ulong3)this; _this.xy = (ulong2)value; this = (long3)_this; } }
        public          long2 xz { readonly get => (long2)((ulong3)this).xz;  set { ulong3 _this = (ulong3)this; _this.xz = (ulong2)value; this = (long3)_this; } }
		public          long2 yx { readonly get => (long2)((ulong3)this).yx;  set { ulong3 _this = (ulong3)this; _this.yx = (ulong2)value; this = (long3)_this; } }
        public readonly long2 yy => (long2)((ulong3)this).yy;
        public          long2 yz { readonly get => (long2)((ulong3)this).yz;  set { ulong3 _this = (ulong3)this; _this.yz = (ulong2)value; this = (long3)_this; } }
		public          long2 zx { readonly get => (long2)((ulong3)this).zx;  set { ulong3 _this = (ulong3)this; _this.zx = (ulong2)value; this = (long3)_this; } }
        public          long2 zy { readonly get => (long2)((ulong3)this).zy;  set { ulong3 _this = (ulong3)this; _this.zy = (ulong2)value; this = (long3)_this; } }
        public readonly long2 zz => (long2)((ulong3)this).zz;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(long3 input) => RegisterConversion.ToRegister256(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(v256 input) => RegisterConversion.ToAbstraction256<long3>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(long input) => new long3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(ulong3 input) => *(long3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(uint3 input) => (long3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(int3 input) => (long3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(half3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new long3((long2)input.xy, (int)maxmath.BASE_cvtf16i32(input.z, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(float3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new long3((long2)input.xy, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(input), 3);
            }
            else
            {
                return new long3((long2)input.xy, (long)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(long3 input) => (uint3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(long3 input) => (int3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf3(Xse.mm256_cvtepi64_ph(input, (half)float.PositiveInfinity, elements: 3));
            }
            else
            {
                return new half3((half2)input.xy, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.mm256_cvtepi64_ps(input, 3));
            }
            else
            {
                return new float3((float2)input._xy, (float)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_cvtepi64_pd(input, 3));
            }
            else
            {
                return new double3((double2)input._xy, (double)input.z);
            }
        }


        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (long)((ulong3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ulong3 _this = (ulong3)this;
                _this[index] = (ulong)value;
                this = (long3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, long3 right) => (long3)((ulong3)left + (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, long3 right) => (long3)((ulong3)left - (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long3 right) => (long3)((ulong3)left * (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, uint3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (uint3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, ushort3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (ushort3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, byte3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (byte3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(right)), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, sbyte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, short3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, int3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(right)), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, right.xy, useFPU: true), left.z / right.z);
			}
			else
			{
				return new long3(left._xy / right._xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(right)), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, sbyte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, short3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, int3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(right)), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right.xy, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, right.xy, useFPU: true), left.z % right.z);
			}
			else
			{
				return new long3(left._xy % right._xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return (v256)((long4)((v256)left) * right);
                }


                return Xse.mm256_mullo_epi64(left, new long4(right));
            }
            else
            {
                return new long3(left._xy * right, left.z * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (int3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constdiv_epi64(left, right, 3);
                    }
                    else
                    {
                        return new long3(Xse.constdiv_epi64(left.xy, right), left.z / right);
                    }
                }
            }

            return left / (long3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (int3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constrem_epi64(left, right, 3);
                    }
                    else
                    {
                        return new long3(Xse.constrem_epi64(left.xy, right), left.z / right);
                    }
                }
            }

            return left % (long3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, long3 right) => (long3)((ulong3)left & (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, long3 right) => (long3)((ulong3)left | (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, long3 right) => (long3)((ulong3)left ^ (ulong3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else
            {
                return new long3(-x._xy, -x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ++ (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi64(x);
            }
            else
            {
                return new long3(x._xy + 1, x.z + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator -- (long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi64(x);
            }
            else
            {
                return new long3(x._xy - 1, x.z - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ~ (long3 x) => (long3)~(ulong3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator << (long3 x, int n) => (long3)((ulong3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator >> (long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srai_epi64(x, n, 3);
            }
            else
            {
                return new long3(x._xy >> n, x.z >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (long3 left, long3 right) => (ulong3)left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmplt_epi64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy < right._xy, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpgt_epi64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy > right._xy, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (long3 left, long3 right) => (ulong3)left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Xse.mm256_cmpgt_epi64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy <= right._xy, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Xse.mm256_cmplt_epi64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy >= right._xy, left.z >= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long3 other) => ((ulong3)this).Equals((ulong3)other);

        public override readonly bool Equals(object obj) => obj is long3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ulong3)this).GetHashCode();


        public override readonly string ToString() => $"long3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}