using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 3)]
    unsafe public struct quarter3 : IEquatable<quarter3>, IFormattable
    {
        [NoAlias] public quarter x;
        [NoAlias] public quarter y;
        [NoAlias] public quarter z;


        public static quarter3 zero => default(quarter3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter y, quarter z)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)z.value, (sbyte)y.value, (sbyte)x.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter xyz)
        {
            this = Sse2.set1_epi8((sbyte)xyz.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter2 xy, quarter z)
        {
            this = Sse4_1.insert_epi8(xy, z.value, 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter2 yz)
        {
            this = Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(quarter)), x.value, 0);
        }


        #region Shuffle
        public quarter8 xxxxxxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxxxxxx); }
        public quarter8 yyyyyyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyyyyyy); }
        public quarter8 zzzzzzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzzzzzz); }
        
        public quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxx); }
        public quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxy); }
        public quarter4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxz); }
        public quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyx); }
        public quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyy); }
        public quarter4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyz); }
        public quarter4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzx); }
        public quarter4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzy); }
        public quarter4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzz); }
        public quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxx); }
        public quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxy); }
        public quarter4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxz); }
        public quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyx); }
        public quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyy); }
        public quarter4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyz); }
        public quarter4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzx); }
        public quarter4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzy); }
        public quarter4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzz); }
        public quarter4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxx); }
        public quarter4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxy); }
        public quarter4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxz); }
        public quarter4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyx); }
        public quarter4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyy); }
        public quarter4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyz); }
        public quarter4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzx); }
        public quarter4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzy); }
        public quarter4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzz); }
        public quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxx); }
        public quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxy); }
        public quarter4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxz); }
        public quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyx); }
        public quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyy); }
        public quarter4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyz); }
        public quarter4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzx); }
        public quarter4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzy); }
        public quarter4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzz); }
        public quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxx); }
        public quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxy); }
        public quarter4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxz); }
        public quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyx); }
        public quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyy); }
        public quarter4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyz); }
        public quarter4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzx); }
        public quarter4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzy); }
        public quarter4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzz); }
        public quarter4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxx); }
        public quarter4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxy); }
        public quarter4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxz); }
        public quarter4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyx); }
        public quarter4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyy); }
        public quarter4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyz); }
        public quarter4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzx); }
        public quarter4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzy); }
        public quarter4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzz); }
        public quarter4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxx); }
        public quarter4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxy); }
        public quarter4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxz); }
        public quarter4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyx); }
        public quarter4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyy); }
        public quarter4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyz); }
        public quarter4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzx); }
        public quarter4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzy); }
        public quarter4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzz); }
        public quarter4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxx); }
        public quarter4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxy); }
        public quarter4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxz); }
        public quarter4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyx); }
        public quarter4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyy); }
        public quarter4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyz); }
        public quarter4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzx); }
        public quarter4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzy); }
        public quarter4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzz); }
        public quarter4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxx); }
        public quarter4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxy); }
        public quarter4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxz); }
        public quarter4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyx); }
        public quarter4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyy); }
        public quarter4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyz); }
        public quarter4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzx); }
        public quarter4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzy); }
        public quarter4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzz); }

        public quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxx); }
        public quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxy); }
        public quarter3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxz); }
        public quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyx); }
        public quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyy); }
        public quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzx); }
        public quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzy; }
        public quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzz); }
        public quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxx); }
        public quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxy); }
        public quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxz; }
        public quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyx); }
        public quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyy); }
        public quarter3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyz); }
        public quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxy; }
        public quarter3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzy); }
        public quarter3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzz); }
        public quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxx); }
        public quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzx; }
        public quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxz); }
        public quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyx; }
        public quarter3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyy); }
        public quarter3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyz); }
        public quarter3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzx); }
        public quarter3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzy); }
        public quarter3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzz); }

        public quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xx); }
        public quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value, 0b0001); }
        public quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyy, new byte3(255, 0, 255)); }
        public quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yxyx, 0b0001); }
        public quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yy); }
        public quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, Sse2.bslli_si128(value, sizeof(quarter)), new byte3(0, 255, 255)); }
        public quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte3(255, 0, 255)); }
        public quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte3(0, 255, 255)); }
        public quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zz); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter3 input) => Sse4_1.insert_epi8(Sse2.insert_epi16(default(v128), *(short*)&input, 0), input.z.value, 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(v128 input) => new quarter3 { x = maxmath.asquarter(input.Byte0), y = maxmath.asquarter(input.Byte1), z = maxmath.asquarter(input.Byte2) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(quarter input) => new quarter3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(sbyte3 input)
        {
            sbyte3 sign = input & (sbyte)-0b1000_0000;
            sbyte3 abs = maxmath.abs(input);
            v128 overflowMask = Sse2.cmpgt_epi8(abs, new sbyte3(15));


            float3 f = abs;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Sse2.andnot_si128(Sse2.cmpeq_epi8(abs, default(v128)), new v128(-1));

            sbyte3 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte3 regular = sign | (notZeroMask & (sbyte3)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(byte3 input)
        {
            v128 overflowMask = Sse2.cmpgt_epi8(input, new byte3(15));


            float3 f = input;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Sse2.andnot_si128(Sse2.cmpeq_epi8(input, default(v128)), new v128(-1));

            byte3 infinity = quarter.PositiveInfinity.value;
            byte3 regular = notZeroMask & (byte3)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(short3 input)
        {
            sbyte3 sign = (sbyte3)((ushort3)input >> 15) << 7;
            short3 abs = maxmath.abs(input);
            v128 overflowMask = (sbyte3)(short3)Sse2.cmpgt_epi16(abs, new short3(15));


            float3 f = abs;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte3)(short3)Sse2.andnot_si128(Sse2.cmpeq_epi16(abs, default(v128)), new v128(-1));

            sbyte3 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte3 regular = sign | (notZeroMask & (sbyte3)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ushort3 input)
        {
            v128 overflowMask = (sbyte3)(ushort3)Sse2.cmpgt_epi16(input, new ushort3(15));


            float3 f = input;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte3)(ushort3)Sse2.andnot_si128(Sse2.cmpeq_epi16(input, default(v128)), new v128(-1));

            byte3 infinity = quarter.PositiveInfinity.value;
            byte3 regular = notZeroMask & (byte3)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(int3 input)
        {
            sbyte3 sign = (sbyte3)((uint3)input >> 31) << 7;
            int3 abs = math.abs(input);
            v128 overflowMask = Cast.Int4ToByte4(Sse2.cmpgt_epi32(*(v128*)&abs, new v128(15)));


            float3 f = abs;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Cast.Int4ToByte4(Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&abs, default(v128)), new v128(-1)));

            sbyte3 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte3 regular = sign | (notZeroMask & (sbyte3)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(uint3 input)
        {
            v128 overflowMask = Cast.Int4ToByte4(Sse2.cmpgt_epi32(*(v128*)&input, new v128(15)));


            float3 f = input;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = Cast.Int4ToByte4(Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&input, default(v128)), new v128(-1)));

            byte3 infinity = quarter.PositiveInfinity.value;
            byte3 regular = notZeroMask & (byte3)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(long3 input)
        {
            sbyte3 sign = (sbyte3)((ulong3)input >> 63) << 7;
            long3 abs = maxmath.abs(input);
            v128 overflowMask = (sbyte3)(long3)Avx2.mm256_cmpgt_epi64(abs, new long3(15));


            float3 f = (int3)abs;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte3)(long3)Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(abs, default(v256)), new v256(-1));

            sbyte3 infinity = sign | (sbyte)quarter.PositiveInfinity.value;
            sbyte3 regular = sign | (notZeroMask & (sbyte3)f32);

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ulong3 input)
        {
            v128 overflowMask = (sbyte3)(ulong3)Avx2.mm256_cmpgt_epi64(input, new ulong3(15));


            float3 f = (int3)input;

            int3 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
            f32 >>= 19;

            v128 notZeroMask = (sbyte3)(ulong3)Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(input, default(v256)), new v256(-1));

            byte3 infinity = quarter.PositiveInfinity.value;
            byte3 regular = notZeroMask & (byte3)f32;

            return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(half3 input)
        {
            byte3 f8_sign      = (byte3)((maxmath.asushort(input) >> 15) << 7);
            uint3 f16_exponent = (maxmath.asushort(input) >> 10) & 0x001F;


            uint3 f16_mantissa = maxmath.asushort(input) & 0x03FF;

            int3 cmp = 13 - (int3)f16_exponent;
            v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

            int3 denormalShift = maxmath.shrl((int3)0b0001_0000, cmp);
            v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
            denormalExponent = Sse2.add_epi32(denormalExponent, 
                                              Sse2.and_si128(new v128(1), 
                                                             Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(9)), 
                                                                            Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0200), 
                                                                                                               *(v128*)&f16_mantissa), 
                                                                                              new v128(-1)))));

            v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                           Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(8)),
                                                                          Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f16_mantissa, default(v128)),  new v128(-1))));

            int3 normalExponent = (*(int3*)&cmpIsZeroOrNegativeMask & ((int3)f16_exponent - (15 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

            int3 mantissaShift = 6 + maxmath.andnot(cmp, *(int3*)&cmpIsZeroOrNegativeMask);


            v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                  Sse2.or_si128(mantissaIfSmallerEpsilon, Avx2.srlv_epi32(*(v128*)&f16_mantissa, *(v128*)&mantissaShift)));

            v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                        Sse2.and_si128(new v128(1),
                                                                       Sse2.cmpgt_epi32(Sse2.and_si128(Sse4_1.cvtepu16_epi32(maxmath.asushort(input)), new v128(maxmath.bitmask32(15))),
                                                                                        new v128(0x7C00))));

            v128 underflowMask = Sse2.cmpgt_epi32(new v128(8), *(v128*)&f16_exponent);
            v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f16_exponent, new v128(18));

            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);
            
            return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(float3 input)
        {
            byte3 f8_sign      = (byte3)((math.asuint(input) >> 31) << 7);
            uint3 f32_exponent = (math.asuint(input) >> 23) & 0x00FF;


            uint3 f32_mantissa = math.asuint(input) & 0x007F_FFFFu;

            int3 cmp = 125 - (int3)f32_exponent;
            v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

            int3 denormalShift = maxmath.shrl((int3)0b0001_0000, cmp);
            v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
            denormalExponent = Sse2.add_epi32(denormalExponent, 
                                              Sse2.and_si128(new v128(1), 
                                                             Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(121)), 
                                                                            Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0040_0000), 
                                                                                                               *(v128*)&f32_mantissa), 
                                                                                              new v128(-1)))));

            v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                           Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(120)),
                                                                          Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f32_mantissa, default(v128)),  new v128(-1))));

            int3 normalExponent = (*(int3*)&cmpIsZeroOrNegativeMask & ((int3)f32_exponent - (127 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

            int3 mantissaShift = 19 + maxmath.andnot(cmp, *(int3*)&cmpIsZeroOrNegativeMask);


            v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                  Sse2.or_si128(mantissaIfSmallerEpsilon, Avx2.srlv_epi32(*(v128*)&f32_mantissa, *(v128*)&mantissaShift)));

            v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                        Sse2.and_si128(new v128(1),
                                                                       Sse2.cmpgt_epi32(Sse.and_ps(*(v128*)&input, new v128(maxmath.bitmask32(31))),
                                                                                        new v128(0x7F80_0000))));

            v128 underflowMask = Sse2.cmpgt_epi32(new v128(120), *(v128*)&f32_exponent);
            v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f32_exponent, new v128(130));

            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);
            
            return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(double3 input)
        {
            byte3 f8_sign      = (byte3)((maxmath.asulong(input) >> 63) << 7);
            uint3 f64_exponent = (uint3)(maxmath.asulong(input) >> 52) & 0x07FF;


            ulong3 f64_mantissa = maxmath.asulong(input) & 0x000F_FFFF_FFFF_FFFFul;

            int3 cmp = 1021 - (int3)f64_exponent;
            v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

            int3 denormalShift = maxmath.shrl((int3)0b0001_0000, cmp);
            v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
            denormalExponent = Sse2.add_epi32(denormalExponent, 
                                              Sse2.and_si128(new v128(1), 
                                                             Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1017)), 
                                                                            Cast.Long4ToInt4(Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi64(new v256(0x0008_0000_0000_0000ul),
                                                                                                                                            f64_mantissa), 
                                                                                                                         new v256(-1))))));

            v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                           Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1016)),
                                                                           Cast.Long4ToInt4(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f64_mantissa, default(v256)),  new v256(-1)))));

            int3 normalExponent = (*(int3*)&cmpIsZeroOrNegativeMask & ((int3)f64_exponent - (1023 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

            int3 mantissaShift = 48 + maxmath.andnot(cmp, *(int3*)&cmpIsZeroOrNegativeMask);


            v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                  Sse2.or_si128(mantissaIfSmallerEpsilon, Cast.Long4ToInt4(Avx2.mm256_srlv_epi64(f64_mantissa, (ulong3)mantissaShift))));

            v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                        Sse2.and_si128(new v128(1),
                                                                       Cast.Long4ToInt4(Avx2.mm256_cmpgt_epi64(Avx.mm256_and_pd(*(v256*)&input, new v256(maxmath.bitmask64(63L))),
                                                                                                               new v256(0x7FF0_0000_0000_0000L)))));

            v128 underflowMask = Sse2.cmpgt_epi32(new v128(1016), *(v128*)&f64_exponent);
            v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f64_exponent, new v128(1026));

            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
            exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);
            
            return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(quarter3 input) => (sbyte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(quarter3 input) => (byte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(quarter3 input) => (short3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(quarter3 input) => (ushort3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(quarter3 input) => (int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(quarter3 input) => (uint3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(quarter3 input) => (int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(quarter3 input) => (uint3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(quarter3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(quarter3 input)
        {
            uint3 widen = maxmath.asbyte(input);

            uint3 signMask = 0b1000_0000;
            uint3 sign = (widen & signMask) << 24;
            uint3 fusedExponentMantissa = maxmath.andnot(widen, signMask) << (23 - quarter.MANTISSA_BITS);

            bool3 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            uint3 nanInfinityOrZeroExponent = math.select(0u, 255u << 23, isNanOrInfinity);
            float3 magic = math.select(math.asfloat((255 - 1 + quarter.EXPONENT_BIAS) << 23), 1f, isNanOrInfinity);

            return magic * math.asfloat(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(quarter3 input)
        {
            ulong3 widen = maxmath.asbyte(input);
             
            ulong3 signMask = 0b1000_0000;
            ulong3 sign = (widen & signMask) << 56;
            ulong3 fusedExponentMantissa = maxmath.andnot(widen, signMask) << (52 - quarter.MANTISSA_BITS);

            bool3 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            ulong3 nanInfinityOrZeroExponent = maxmath.select(0ul, 2047ul << 52, isNanOrInfinity);
            double3 magic = math.select(math.asdouble((2047L - 1L + quarter.EXPONENT_BIAS) << 52), 1d, isNanOrInfinity);

            return magic * maxmath.asdouble(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);
                
                fixed (void* ptr = &this)
                {
                    return ((quarter*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    ((quarter*)ptr)[index] = value;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, quarter3 right)
        {
            v128 maskedLeft  = Sse2.and_si128(left,  new byte3(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(right, new byte3(0b0111_1111));


            v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte3(0b0111_0000)), new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte3(0b0111_0000)), new v128(-1)));

            v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                       Sse2.cmpeq_epi8(default(v128), maskedRight));

            v128 value = Sse2.cmpeq_epi8(left, right);


            v128 result = Sse2.and_si128(new byte3(1), Sse2.and_si128(nan, Sse2.or_si128(zero, value)));

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, quarter3 right)
        {
            v128 maskedLeft  = Sse2.and_si128(left,  new byte3(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(right, new byte3(0b0111_1111));


            v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte3(0b0111_0000)),
                                     Sse2.cmpgt_epi8(maskedRight, new byte3(0b0111_0000)));

            v128 zero = Sse2.or_si128(Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),  new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedRight), new v128(-1)));

            v128 value = Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128(-1));


            v128 result = Sse2.and_si128(new byte3(1), Sse2.or_si128(nan, Sse2.and_si128(zero, value)));

            return *(bool3*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter3 other)
        {
            v128 maskedLeft  = Sse2.and_si128(this,  new byte3(0b0111_1111));
            v128 maskedRight = Sse2.and_si128(other, new byte3(0b0111_1111));


            v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft,  new byte3(0b0111_0000)), new v128(-1)),
                                      Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte3(0b0111_0000)), new v128(-1)));

            v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                       Sse2.cmpeq_epi8(default(v128), maskedRight));

            v128 value = Sse2.cmpeq_epi8(this, other);


            v128 result = Sse2.and_si128(nan, Sse2.or_si128(zero, value));

            return (result.UInt0 & 0x00FF_FFFF) == 0x00FF_FFFF;
        }

        public override bool Equals(object obj) => Equals((quarter3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v24(this);


        public override string ToString() => $"quarter3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}