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
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(short))]
    [DebuggerTypeProxy(typeof(short3.DebuggerProxy))]
    unsafe public struct short3 : IEquatable<short3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public short x;
            public short y;
            public short z;

            public DebuggerProxy(short3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
        [FieldOffset(4)] public short z;


        public static short3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short y, short z)
        {
            this = (short3)new ushort3((ushort)x, (ushort)y, (ushort)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short xyz)
        {
            this = (short3)new ushort3((ushort)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short2 xy, short z)
        {
            this = (short3)new ushort3((ushort2)xy, (ushort)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short2 yz)
        {
            this = (short3)new ushort3((ushort)x, (ushort2)yz);
        }


        #region Shuffle
        public readonly short4 xxxx => (short4)((ushort3)this).xxxx;
        public readonly short4 xxxy => (short4)((ushort3)this).xxxy;
        public readonly short4 xxxz => (short4)((ushort3)this).xxxz;
        public readonly short4 xxyx => (short4)((ushort3)this).xxyx;
        public readonly short4 xxyy => (short4)((ushort3)this).xxyy;
        public readonly short4 xxyz => (short4)((ushort3)this).xxyz;
        public readonly short4 xxzx => (short4)((ushort3)this).xxzx;
        public readonly short4 xxzy => (short4)((ushort3)this).xxzy;
        public readonly short4 xxzz => (short4)((ushort3)this).xxzz;
        public readonly short4 xyxx => (short4)((ushort3)this).xyxx;
		public readonly short4 xyxy => (short4)((ushort3)this).xyxy;
        public readonly short4 xyxz => (short4)((ushort3)this).xyxz;
		public readonly short4 xyyx => (short4)((ushort3)this).xyyx;
		public readonly short4 xyyy => (short4)((ushort3)this).xyyy;
		public readonly short4 xyyz => (short4)((ushort3)this).xyyz;
		public readonly short4 xyzx => (short4)((ushort3)this).xyzx;
        public readonly short4 xyzy => (short4)((ushort3)this).xyzy;
        public readonly short4 xyzz => (short4)((ushort3)this).xyzz;
		public readonly short4 xzxx => (short4)((ushort3)this).xzxx;
        public readonly short4 xzxy => (short4)((ushort3)this).xzxy;
        public readonly short4 xzxz => (short4)((ushort3)this).xzxz;
		public readonly short4 xzyx => (short4)((ushort3)this).xzyx;
        public readonly short4 xzyy => (short4)((ushort3)this).xzyy;
        public readonly short4 xzyz => (short4)((ushort3)this).xzyz;
		public readonly short4 xzzx => (short4)((ushort3)this).xzzx;
        public readonly short4 xzzy => (short4)((ushort3)this).xzzy;
        public readonly short4 xzzz => (short4)((ushort3)this).xzzz;
		public readonly short4 yxxx => (short4)((ushort3)this).yxxx;
        public readonly short4 yxxy => (short4)((ushort3)this).yxxy;
        public readonly short4 yxxz => (short4)((ushort3)this).yxxz;
		public readonly short4 yxyx => (short4)((ushort3)this).yxyx;
        public readonly short4 yxyy => (short4)((ushort3)this).yxyy;
        public readonly short4 yxyz => (short4)((ushort3)this).yxyz;
		public readonly short4 yxzx => (short4)((ushort3)this).yxzx;
        public readonly short4 yxzy => (short4)((ushort3)this).yxzy;
        public readonly short4 yxzz => (short4)((ushort3)this).yxzz;
		public readonly short4 yyxx => (short4)((ushort3)this).yyxx;
        public readonly short4 yyxy => (short4)((ushort3)this).yyxy;
        public readonly short4 yyxz => (short4)((ushort3)this).yyxz;
		public readonly short4 yyyx => (short4)((ushort3)this).yyyx;
        public readonly short4 yyyy => (short4)((ushort3)this).yyyy;
        public readonly short4 yyyz => (short4)((ushort3)this).yyyz;
		public readonly short4 yyzx => (short4)((ushort3)this).yyzx;
        public readonly short4 yyzy => (short4)((ushort3)this).yyzy;
        public readonly short4 yyzz => (short4)((ushort3)this).yyzz;
		public readonly short4 yzxx => (short4)((ushort3)this).yzxx;
        public readonly short4 yzxy => (short4)((ushort3)this).yzxy;
        public readonly short4 yzxz => (short4)((ushort3)this).yzxz;
		public readonly short4 yzyx => (short4)((ushort3)this).yzyx;
        public readonly short4 yzyy => (short4)((ushort3)this).yzyy;
        public readonly short4 yzyz => (short4)((ushort3)this).yzyz;
		public readonly short4 yzzx => (short4)((ushort3)this).yzzx;
        public readonly short4 yzzy => (short4)((ushort3)this).yzzy;
        public readonly short4 yzzz => (short4)((ushort3)this).yzzz;
		public readonly short4 zxxx => (short4)((ushort3)this).zxxx;
        public readonly short4 zxxy => (short4)((ushort3)this).zxxy;
        public readonly short4 zxxz => (short4)((ushort3)this).zxxz;
		public readonly short4 zxyx => (short4)((ushort3)this).zxyx;
        public readonly short4 zxyy => (short4)((ushort3)this).zxyy;
        public readonly short4 zxyz => (short4)((ushort3)this).zxyz;
		public readonly short4 zxzx => (short4)((ushort3)this).zxzx;
        public readonly short4 zxzy => (short4)((ushort3)this).zxzy;
        public readonly short4 zxzz => (short4)((ushort3)this).zxzz;
		public readonly short4 zyxx => (short4)((ushort3)this).zyxx;
        public readonly short4 zyxy => (short4)((ushort3)this).zyxy;
        public readonly short4 zyxz => (short4)((ushort3)this).zyxz;
		public readonly short4 zyyx => (short4)((ushort3)this).zyyx;
        public readonly short4 zyyy => (short4)((ushort3)this).zyyy;
        public readonly short4 zyyz => (short4)((ushort3)this).zyyz;
		public readonly short4 zyzx => (short4)((ushort3)this).zyzx;
        public readonly short4 zyzy => (short4)((ushort3)this).zyzy;
        public readonly short4 zyzz => (short4)((ushort3)this).zyzz;
		public readonly short4 zzxx => (short4)((ushort3)this).zzxx;
        public readonly short4 zzxy => (short4)((ushort3)this).zzxy;
        public readonly short4 zzxz => (short4)((ushort3)this).zzxz;
		public readonly short4 zzyx => (short4)((ushort3)this).zzyx;
        public readonly short4 zzyy => (short4)((ushort3)this).zzyy;
        public readonly short4 zzyz => (short4)((ushort3)this).zzyz;
		public readonly short4 zzzx => (short4)((ushort3)this).zzzx;
        public readonly short4 zzzy => (short4)((ushort3)this).zzzy;
        public readonly short4 zzzz => (short4)((ushort3)this).zzzz;

		public readonly short3 xxx => (short3)((ushort3)this).xxx;
        public readonly short3 xxy => (short3)((ushort3)this).xxy;
        public readonly short3 xxz => (short3)((ushort3)this).xxz;
		public readonly short3 xyx => (short3)((ushort3)this).xyx;
        public readonly short3 xyy => (short3)((ushort3)this).xyy;
		public readonly short3 xzx => (short3)((ushort3)this).xzx;
        public          short3 xzy { readonly get => (short3)((ushort3)this).xzy;  set { ushort3 _this = (ushort3)this; _this.xzy = (ushort3)value; this = (short3)_this; } }
        public readonly short3 xzz => (short3)((ushort3)this).xzz;
		public readonly short3 yxx => (short3)((ushort3)this).yxx;
        public readonly short3 yxy => (short3)((ushort3)this).yxy;
        public          short3 yxz { readonly get => (short3)((ushort3)this).yxz;  set { ushort3 _this = (ushort3)this; _this.yxz = (ushort3)value; this = (short3)_this; } }
		public readonly short3 yyx => (short3)((ushort3)this).yyx;
        public readonly short3 yyy => (short3)((ushort3)this).yyy;
        public readonly short3 yyz => (short3)((ushort3)this).yyz;
		public          short3 yzx { readonly get => (short3)((ushort3)this).yzx;  set { ushort3 _this = (ushort3)this; _this.yzx = (ushort3)value; this = (short3)_this; } }
        public readonly short3 yzy => (short3)((ushort3)this).yzy;
        public readonly short3 yzz => (short3)((ushort3)this).yzz;
		public readonly short3 zxx => (short3)((ushort3)this).zxx;
        public          short3 zxy { readonly get => (short3)((ushort3)this).zxy;  set { ushort3 _this = (ushort3)this; _this.zxy = (ushort3)value; this = (short3)_this; } }
        public readonly short3 zxz => (short3)((ushort3)this).zxz;
		public          short3 zyx { readonly get => (short3)((ushort3)this).zyx;  set { ushort3 _this = (ushort3)this; _this.zyx = (ushort3)value; this = (short3)_this; } }
        public readonly short3 zyy => (short3)((ushort3)this).zyy;
        public readonly short3 zyz => (short3)((ushort3)this).zyz;
		public readonly short3 zzx => (short3)((ushort3)this).zzx;
        public readonly short3 zzy => (short3)((ushort3)this).zzy;
        public readonly short3 zzz => (short3)((ushort3)this).zzz;

		public readonly short2 xx => (short2)((ushort3)this).xx;
        public          short2 xy { readonly get => (short2)((ushort3)this).xy;  set { ushort3 _this = (ushort3)this; _this.xy = (ushort2)value; this = (short3)_this; } }
        public          short2 xz { readonly get => (short2)((ushort3)this).xz;  set { ushort3 _this = (ushort3)this; _this.xz = (ushort2)value; this = (short3)_this; } }
		public          short2 yx { readonly get => (short2)((ushort3)this).yx;  set { ushort3 _this = (ushort3)this; _this.yx = (ushort2)value; this = (short3)_this; } }
        public readonly short2 yy => (short2)((ushort3)this).yy;
        public          short2 yz { readonly get => (short2)((ushort3)this).yz;  set { ushort3 _this = (ushort3)this; _this.yz = (ushort2)value; this = (short3)_this; } }
		public          short2 zx { readonly get => (short2)((ushort3)this).zx;  set { ushort3 _this = (ushort3)this; _this.zx = (ushort2)value; this = (short3)_this; } }
        public          short2 zy { readonly get => (short2)((ushort3)this).zy;  set { ushort3 _this = (ushort3)this; _this.zy = (ushort2)value; this = (short3)_this; } }
        public readonly short2 zz => (short2)((ushort3)this).zz;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short3 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(v128 input) => RegisterConversion.ToAbstraction128<short3>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(short input) => new short3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ushort3 input) => *(short3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(int3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(uint3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(long3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ulong3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new short3((short)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.z, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(float3 input) => (short3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(double3 input) => (short3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepi16_ph(input, elements: 3));
            }
            else
            {
                return (half3)(float3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float3)(int3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(short3 input) => (double3)(int3)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort3 _this = (ushort3)this;
                _this[index] = (ushort)value;
                this = (short3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, short3 right) => (short3)((ushort3)left + (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, short3 right) => (short3)((ushort3)left - (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short3 right) => (short3)((ushort3)left * (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 3);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 3);
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short left, short3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return (v128)((short8)((v128)left) * right);
                }
            }

            return left * (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 3);
                }
            }

            return left / (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 3);
                }
            }

            return left % (short3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, short3 right) => (short3)((ushort3)left & (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, short3 right) => (short3)((ushort3)left | (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, short3 right) => (short3)((ushort3)left ^ (ushort3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short3((short)-x.x, (short)-x.y, (short)-x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ++ (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new short3((short)(x.x + 1), (short)(x.y + 1), (short)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator -- (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new short3((short)(x.x - 1), (short)(x.y - 1), (short)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ~ (short3 x) => (short3)~(ushort3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator << (short3 x, int n) => (short3)((ushort3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator >> (short3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short3((short)(x.x >> n), (short)(x.y >> n), (short)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (short3 left, short3 right) => (ushort3)left == (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmplt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpgt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (short3 left, short3 right) => (ushort3)left != (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmpgt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmplt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short3 other) => ((ushort3)this).Equals((ushort3)other);

        public override readonly bool Equals(object obj) => obj is short3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ushort3)this).GetHashCode();


        public override readonly string ToString() => $"short3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}