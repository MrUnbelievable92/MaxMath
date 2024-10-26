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
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(sbyte))]
    [DebuggerTypeProxy(typeof(sbyte3.DebuggerProxy))]
    unsafe public struct sbyte3 : IEquatable<sbyte3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public sbyte x;
            public sbyte y;
            public sbyte z;

            public DebuggerProxy(sbyte3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;
        [FieldOffset(2)] public sbyte z;


        public static sbyte3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte y, sbyte z)
        {
            this = (sbyte3)new byte3((byte)x, (byte)y, (byte)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte xyz)
        {
            this = (sbyte3)new byte3((byte)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte2 xy, sbyte z)
        {
            this = (sbyte3)new byte3((byte2)xy, (byte)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte2 yz)
        {
            this = (sbyte3)new byte3((byte)x, (byte2)yz);
        }


        #region Shuffle
		public readonly sbyte4 xxxx => (sbyte4)((byte3)this).xxxx;
        public readonly sbyte4 xxxy => (sbyte4)((byte3)this).xxxy;
        public readonly sbyte4 xxxz => (sbyte4)((byte3)this).xxxz;
        public readonly sbyte4 xxyx => (sbyte4)((byte3)this).xxyx;
        public readonly sbyte4 xxyy => (sbyte4)((byte3)this).xxyy;
        public readonly sbyte4 xxyz => (sbyte4)((byte3)this).xxyz;
        public readonly sbyte4 xxzx => (sbyte4)((byte3)this).xxzx;
        public readonly sbyte4 xxzy => (sbyte4)((byte3)this).xxzy;
        public readonly sbyte4 xxzz => (sbyte4)((byte3)this).xxzz;
        public readonly sbyte4 xyxx => (sbyte4)((byte3)this).xyxx;
		public readonly sbyte4 xyxy => (sbyte4)((byte3)this).xyxy;
        public readonly sbyte4 xyxz => (sbyte4)((byte3)this).xyxz;
		public readonly sbyte4 xyyx => (sbyte4)((byte3)this).xyyx;
		public readonly sbyte4 xyyy => (sbyte4)((byte3)this).xyyy;
		public readonly sbyte4 xyyz => (sbyte4)((byte3)this).xyyz;
		public readonly sbyte4 xyzx => (sbyte4)((byte3)this).xyzx;
        public readonly sbyte4 xyzy => (sbyte4)((byte3)this).xyzy;
        public readonly sbyte4 xyzz => (sbyte4)((byte3)this).xyzz;
		public readonly sbyte4 xzxx => (sbyte4)((byte3)this).xzxx;
        public readonly sbyte4 xzxy => (sbyte4)((byte3)this).xzxy;
        public readonly sbyte4 xzxz => (sbyte4)((byte3)this).xzxz;
		public readonly sbyte4 xzyx => (sbyte4)((byte3)this).xzyx;
        public readonly sbyte4 xzyy => (sbyte4)((byte3)this).xzyy;
        public readonly sbyte4 xzyz => (sbyte4)((byte3)this).xzyz;
		public readonly sbyte4 xzzx => (sbyte4)((byte3)this).xzzx;
        public readonly sbyte4 xzzy => (sbyte4)((byte3)this).xzzy;
        public readonly sbyte4 xzzz => (sbyte4)((byte3)this).xzzz;
		public readonly sbyte4 yxxx => (sbyte4)((byte3)this).yxxx;
        public readonly sbyte4 yxxy => (sbyte4)((byte3)this).yxxy;
        public readonly sbyte4 yxxz => (sbyte4)((byte3)this).yxxz;
		public readonly sbyte4 yxyx => (sbyte4)((byte3)this).yxyx;
        public readonly sbyte4 yxyy => (sbyte4)((byte3)this).yxyy;
        public readonly sbyte4 yxyz => (sbyte4)((byte3)this).yxyz;
		public readonly sbyte4 yxzx => (sbyte4)((byte3)this).yxzx;
        public readonly sbyte4 yxzy => (sbyte4)((byte3)this).yxzy;
        public readonly sbyte4 yxzz => (sbyte4)((byte3)this).yxzz;
		public readonly sbyte4 yyxx => (sbyte4)((byte3)this).yyxx;
        public readonly sbyte4 yyxy => (sbyte4)((byte3)this).yyxy;
        public readonly sbyte4 yyxz => (sbyte4)((byte3)this).yyxz;
		public readonly sbyte4 yyyx => (sbyte4)((byte3)this).yyyx;
        public readonly sbyte4 yyyy => (sbyte4)((byte3)this).yyyy;
        public readonly sbyte4 yyyz => (sbyte4)((byte3)this).yyyz;
		public readonly sbyte4 yyzx => (sbyte4)((byte3)this).yyzx;
        public readonly sbyte4 yyzy => (sbyte4)((byte3)this).yyzy;
        public readonly sbyte4 yyzz => (sbyte4)((byte3)this).yyzz;
		public readonly sbyte4 yzxx => (sbyte4)((byte3)this).yzxx;
        public readonly sbyte4 yzxy => (sbyte4)((byte3)this).yzxy;
        public readonly sbyte4 yzxz => (sbyte4)((byte3)this).yzxz;
		public readonly sbyte4 yzyx => (sbyte4)((byte3)this).yzyx;
        public readonly sbyte4 yzyy => (sbyte4)((byte3)this).yzyy;
        public readonly sbyte4 yzyz => (sbyte4)((byte3)this).yzyz;
		public readonly sbyte4 yzzx => (sbyte4)((byte3)this).yzzx;
        public readonly sbyte4 yzzy => (sbyte4)((byte3)this).yzzy;
        public readonly sbyte4 yzzz => (sbyte4)((byte3)this).yzzz;
		public readonly sbyte4 zxxx => (sbyte4)((byte3)this).zxxx;
        public readonly sbyte4 zxxy => (sbyte4)((byte3)this).zxxy;
        public readonly sbyte4 zxxz => (sbyte4)((byte3)this).zxxz;
		public readonly sbyte4 zxyx => (sbyte4)((byte3)this).zxyx;
        public readonly sbyte4 zxyy => (sbyte4)((byte3)this).zxyy;
        public readonly sbyte4 zxyz => (sbyte4)((byte3)this).zxyz;
		public readonly sbyte4 zxzx => (sbyte4)((byte3)this).zxzx;
        public readonly sbyte4 zxzy => (sbyte4)((byte3)this).zxzy;
        public readonly sbyte4 zxzz => (sbyte4)((byte3)this).zxzz;
		public readonly sbyte4 zyxx => (sbyte4)((byte3)this).zyxx;
        public readonly sbyte4 zyxy => (sbyte4)((byte3)this).zyxy;
        public readonly sbyte4 zyxz => (sbyte4)((byte3)this).zyxz;
		public readonly sbyte4 zyyx => (sbyte4)((byte3)this).zyyx;
        public readonly sbyte4 zyyy => (sbyte4)((byte3)this).zyyy;
        public readonly sbyte4 zyyz => (sbyte4)((byte3)this).zyyz;
		public readonly sbyte4 zyzx => (sbyte4)((byte3)this).zyzx;
        public readonly sbyte4 zyzy => (sbyte4)((byte3)this).zyzy;
        public readonly sbyte4 zyzz => (sbyte4)((byte3)this).zyzz;
		public readonly sbyte4 zzxx => (sbyte4)((byte3)this).zzxx;
        public readonly sbyte4 zzxy => (sbyte4)((byte3)this).zzxy;
        public readonly sbyte4 zzxz => (sbyte4)((byte3)this).zzxz;
		public readonly sbyte4 zzyx => (sbyte4)((byte3)this).zzyx;
        public readonly sbyte4 zzyy => (sbyte4)((byte3)this).zzyy;
        public readonly sbyte4 zzyz => (sbyte4)((byte3)this).zzyz;
		public readonly sbyte4 zzzx => (sbyte4)((byte3)this).zzzx;
        public readonly sbyte4 zzzy => (sbyte4)((byte3)this).zzzy;
        public readonly sbyte4 zzzz => (sbyte4)((byte3)this).zzzz;

		public readonly sbyte3 xxx => (sbyte3)((byte3)this).xxx;
        public readonly sbyte3 xxy => (sbyte3)((byte3)this).xxy;
        public readonly sbyte3 xxz => (sbyte3)((byte3)this).xxz;
		public readonly sbyte3 xyx => (sbyte3)((byte3)this).xyx;
        public readonly sbyte3 xyy => (sbyte3)((byte3)this).xyy;
		public          sbyte3 xyz { readonly get => (sbyte3)((byte3)this).xyz;  set { byte3 _this = (byte3)this; _this.xyz = (byte3)value; this = (sbyte3)_this; } }
		public readonly sbyte3 xzx => (sbyte3)((byte3)this).xzx;
        public          sbyte3 xzy { readonly get => (sbyte3)((byte3)this).xzy;  set { byte3 _this = (byte3)this; _this.xzy = (byte3)value; this = (sbyte3)_this; } }
        public readonly sbyte3 xzz => (sbyte3)((byte3)this).xzz;
		public readonly sbyte3 yxx => (sbyte3)((byte3)this).yxx;
        public readonly sbyte3 yxy => (sbyte3)((byte3)this).yxy;
        public          sbyte3 yxz { readonly get => (sbyte3)((byte3)this).yxz;  set { byte3 _this = (byte3)this; _this.yxz = (byte3)value; this = (sbyte3)_this; } }
		public readonly sbyte3 yyx => (sbyte3)((byte3)this).yyx;
        public readonly sbyte3 yyy => (sbyte3)((byte3)this).yyy;
        public readonly sbyte3 yyz => (sbyte3)((byte3)this).yyz;
		public          sbyte3 yzx { readonly get => (sbyte3)((byte3)this).yzx;  set { byte3 _this = (byte3)this; _this.yzx = (byte3)value; this = (sbyte3)_this; } }
        public readonly sbyte3 yzy => (sbyte3)((byte3)this).yzy;
        public readonly sbyte3 yzz => (sbyte3)((byte3)this).yzz;
		public readonly sbyte3 zxx => (sbyte3)((byte3)this).zxx;
        public          sbyte3 zxy { readonly get => (sbyte3)((byte3)this).zxy;  set { byte3 _this = (byte3)this; _this.zxy = (byte3)value; this = (sbyte3)_this; } }
        public readonly sbyte3 zxz => (sbyte3)((byte3)this).zxz;
		public          sbyte3 zyx { readonly get => (sbyte3)((byte3)this).zyx;  set { byte3 _this = (byte3)this; _this.zyx = (byte3)value; this = (sbyte3)_this; } }
        public readonly sbyte3 zyy => (sbyte3)((byte3)this).zyy;
        public readonly sbyte3 zyz => (sbyte3)((byte3)this).zyz;
		public readonly sbyte3 zzx => (sbyte3)((byte3)this).zzx;
        public readonly sbyte3 zzy => (sbyte3)((byte3)this).zzy;
        public readonly sbyte3 zzz => (sbyte3)((byte3)this).zzz;

		public readonly sbyte2 xx => (sbyte2)((byte3)this).xx;
        public          sbyte2 xy { readonly get => (sbyte2)((byte3)this).xy;  set { byte3 _this = (byte3)this; _this.xy = (byte2)value; this = (sbyte3)_this; } }
        public          sbyte2 xz { readonly get => (sbyte2)((byte3)this).xz;  set { byte3 _this = (byte3)this; _this.xz = (byte2)value; this = (sbyte3)_this; } }
		public          sbyte2 yx { readonly get => (sbyte2)((byte3)this).yx;  set { byte3 _this = (byte3)this; _this.yx = (byte2)value; this = (sbyte3)_this; } }
        public readonly sbyte2 yy => (sbyte2)((byte3)this).yy;
        public          sbyte2 yz { readonly get => (sbyte2)((byte3)this).yz;  set { byte3 _this = (byte3)this; _this.yz = (byte2)value; this = (sbyte3)_this; } }
		public          sbyte2 zx { readonly get => (sbyte2)((byte3)this).zx;  set { byte3 _this = (byte3)this; _this.zx = (byte2)value; this = (sbyte3)_this; } }
        public          sbyte2 zy { readonly get => (sbyte2)((byte3)this).zy;  set { byte3 _this = (byte3)this; _this.zy = (byte2)value; this = (sbyte3)_this; } }
        public readonly sbyte2 zz => (sbyte2)((byte3)this).zz;
		#endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte3 input)
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

            result.SByte0 = input.x;
            result.SByte1 = input.y;
            result.SByte2 = input.z;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(v128 input) => new sbyte3 { x = input.SByte0, y = input.SByte1, z = input.SByte2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(sbyte input) => new sbyte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(byte3 input) => *(sbyte3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(short3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ushort3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(int3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(uint3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(long3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ulong3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(half3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new sbyte3((sbyte)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true),
                                  (sbyte)maxmath.BASE_cvtf16i32(input.z, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(float3 input) => (sbyte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(double3 input) => (sbyte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(sbyte3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(sbyte3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(sbyte3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtepi8_epi32(input));
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(sbyte3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtepi8_epi32(input));
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(sbyte3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(sbyte3 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.cvtepi8_ps(input));
            }
            else
            {
                return (float3)(int3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(sbyte3 input) => (double3)(int3)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte3 _this = (byte3)this;
                _this[index] = (byte)value;
                this = (sbyte3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator + (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left + (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left - (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left * (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 3);
            }
            else
            {
                return new sbyte3((sbyte)(left.x / right.x), (sbyte)(left.y / right.y), (sbyte)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 3);
            }
            else
            {
                return new sbyte3((sbyte)(left.x % right.x), (sbyte)(left.y % right.y), (sbyte)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte left, sbyte3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epi8(left, right, 3);
                }
            }

            return left * (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 3);
                }
            }

            return left / (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 3);
                }
            }

            return left % (sbyte3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator & (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left & (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator | (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left | (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ^ (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left ^ (byte3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)-x.x, (sbyte)-x.y, (sbyte)-x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ++ (sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)(x.x + 1), (sbyte)(x.y + 1), (sbyte)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator -- (sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)(x.x - 1), (sbyte)(x.y - 1), (sbyte)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ~ (sbyte3 x) => (sbyte3)~(byte3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator << (sbyte3 x, int n) => (sbyte3)((byte3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator >> (sbyte3 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true, elements: 3);
            }
            else
            {
                return new sbyte3((sbyte)(x.x >> n), (sbyte)(x.y >> n), (sbyte)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (sbyte3 left, sbyte3 right) => (byte3)left == (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmplt_epi8(left, right));

                return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmpgt_epi8(left, right));

                return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (sbyte3 left, sbyte3 right) => (byte3)left != (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse8(Xse.cmpgt_epi8(left, right));

                return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (sbyte3 left, sbyte3 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse8(Xse.cmplt_epi8(left, right));

                return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte3 other) => ((byte3)this).Equals((byte3)other);

        public override readonly bool Equals(object obj) => obj is sbyte3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((byte3)this).GetHashCode();

        public override readonly string ToString() => $"sbyte3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}