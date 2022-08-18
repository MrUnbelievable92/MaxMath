using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(byte))] 
    [DebuggerTypeProxy(typeof(quarter3.DebuggerProxy))]
    unsafe public struct quarter3 : IEquatable<quarter3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x;
            public quarter y;
            public quarter z;

            public DebuggerProxy(quarter3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[3];

        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;
        [FieldOffset(2)] public quarter z;


        public static quarter3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter y, quarter z)
        {
            this = asquarter(new byte3(x.value, y.value, z.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter xyz)
        {
            this = asquarter(new byte3(xyz.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter2 xy, quarter z)
        {
            this = asquarter(new byte3(asbyte(xy), z.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter2 yz)
        {
            this = asquarter(new byte3(x.value, asbyte(yz)));
        }


        #region Shuffle
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }
        public readonly quarter4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxz); }
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }
        public readonly quarter4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyz); }
        public readonly quarter4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzx); }
        public readonly quarter4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzy); }
        public readonly quarter4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzz); }
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }
        public readonly quarter4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxz); }
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }
        public readonly quarter4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyz); }
        public readonly quarter4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzx); }
        public readonly quarter4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzy); }
        public readonly quarter4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzz); }
        public readonly quarter4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxx); }
        public readonly quarter4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxy); }
        public readonly quarter4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxz); }
        public readonly quarter4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyx); }
        public readonly quarter4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyy); }
        public readonly quarter4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyz); }
        public readonly quarter4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzx); }
        public readonly quarter4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzy); }
        public readonly quarter4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzz); }
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }
        public readonly quarter4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxz); }
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }
        public readonly quarter4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyz); }
        public readonly quarter4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzx); }
        public readonly quarter4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzy); }
        public readonly quarter4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzz); }
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }
        public readonly quarter4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxz); }
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }
        public readonly quarter4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyz); }
        public readonly quarter4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzx); }
        public readonly quarter4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzy); }
        public readonly quarter4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzz); }
        public readonly quarter4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxx); }
        public readonly quarter4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxy); }
        public readonly quarter4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxz); }
        public readonly quarter4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyx); }
        public readonly quarter4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyy); }
        public readonly quarter4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyz); }
        public readonly quarter4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzx); }
        public readonly quarter4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzy); }
        public readonly quarter4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzz); }
        public readonly quarter4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxx); }
        public readonly quarter4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxy); }
        public readonly quarter4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxz); }
        public readonly quarter4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyx); }
        public readonly quarter4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyy); }
        public readonly quarter4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyz); }
        public readonly quarter4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzx); }
        public readonly quarter4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzy); }
        public readonly quarter4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzz); }
        public readonly quarter4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxx); }
        public readonly quarter4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxy); }
        public readonly quarter4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxz); }
        public readonly quarter4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyx); }
        public readonly quarter4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyy); }
        public readonly quarter4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyz); }
        public readonly quarter4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzx); }
        public readonly quarter4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzy); }
        public readonly quarter4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzz); }
        public readonly quarter4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxx); }
        public readonly quarter4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxy); }
        public readonly quarter4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxz); }
        public readonly quarter4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyx); }
        public readonly quarter4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyy); }
        public readonly quarter4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyz); }
        public readonly quarter4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzx); }
        public readonly quarter4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzy); }
        public readonly quarter4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzz); }

        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }
        public readonly quarter3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxz); }
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }
        public readonly quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzx); }
        public          quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzy; }
        public readonly quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzz); }
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }
        public          quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxz; }
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }
        public readonly quarter3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyz); }
        public          quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxy; }
        public readonly quarter3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzy); }
        public readonly quarter3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzz); }
        public readonly quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxx); }
        public          quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzx; }
        public readonly quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxz); }
        public          quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyx; }
        public readonly quarter3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyy); }
        public readonly quarter3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyz); }
        public readonly quarter3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzx); }
        public readonly quarter3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzy); }
        public readonly quarter3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzz); }

        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }
        public          quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.xy = asbyte(value); this = asquarter(temp); } }
        public          quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.xz = asbyte(value); this = asquarter(temp); } }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.yx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }                                                                                                  
        public          quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.yz = asbyte(value); this = asquarter(temp); } }
        public          quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.zx = asbyte(value); this = asquarter(temp); } }
        public          quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.zy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zz); }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter3 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(v128 input) => RegisterConversion.ToType<quarter3>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(quarter input) => new quarter3(input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 SByte3ToQuarter3(sbyte3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi8_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.SByteToQuarter(input.x, overflowValue), 
                                    quarter.SByteToQuarter(input.y, overflowValue), 
                                    quarter.SByteToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(sbyte3 input)
        {
            return SByte3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 Byte3ToQuarter3(byte3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu8_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.ByteToQuarter(input.x, overflowValue), 
                                    quarter.ByteToQuarter(input.y, overflowValue), 
                                    quarter.ByteToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(byte3 input)
        {
            return Byte3ToQuarter3(input, quarter.PositiveInfinity);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 Short3ToQuarter3(short3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi16_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.ShortToQuarter(input.x, overflowValue), 
                                    quarter.ShortToQuarter(input.y, overflowValue), 
                                    quarter.ShortToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(short3 input)
        {
            return Short3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 UShort3ToQuarter3(ushort3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu16_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.UShortToQuarter(input.x, overflowValue), 
                                    quarter.UShortToQuarter(input.y, overflowValue), 
                                    quarter.UShortToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ushort3 input)
        {
            return UShort3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 Int3ToQuarter3(int3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.IntToQuarter(input.x, overflowValue), 
                                    quarter.IntToQuarter(input.y, overflowValue), 
                                    quarter.IntToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(int3 input)
        {
            return Int3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 UInt3ToQuarter3(uint3 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter.UIntToQuarter(input.x, overflowValue), 
                                    quarter.UIntToQuarter(input.y, overflowValue), 
                                    quarter.UIntToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(uint3 input)
        {
            return UInt3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 Long3ToQuarter3(long3 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtepi64_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter2.Long2ToQuarter2(input.xy, overflowValue), 
                                    quarter.LongToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(long3 input)
        {
            return Long3ToQuarter3(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 ULong3ToQuarter3(ulong3 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtepu64_pq(input, overflowValue, elements: 3);
            }
            else
            {
                return new quarter3(quarter2.ULong2ToQuarter2(input.xy, overflowValue), 
                                    quarter.ULongToQuarter(input.z, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ulong3 input)
        {
            return ULong3ToQuarter3(input, quarter.PositiveInfinity);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(half3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtph_pq(RegisterConversion.ToV128(input), elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x, (quarter)input.y, (quarter)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(float3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(input), elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x, (quarter)input.y, (quarter)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 FloatToQuarterInRange(float3 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: true, elements: 3);
            }
            else
            {
                return new quarter3(quarter.FloatToQuarterInRange(f.x), quarter.FloatToQuarterInRange(f.y), quarter.FloatToQuarterInRange(f.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 FloatToQuarterInRangeAbs(float3 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseAbsoluteAndInRange: true, elements: 3);
            }
            else
            {
                return new quarter3(quarter.FloatToQuarterInRangeAbs(f.x), quarter.FloatToQuarterInRangeAbs(f.y), quarter.FloatToQuarterInRangeAbs(f.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(input), elements: 3);
            }
            else
            {
                return new quarter3((quarter2)input.xy, (quarter)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 DoubleToQuarterInRange(double3 d)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(d), promiseInRange: true, elements: 3);
            }
            else
            {
                return new quarter3(quarter2.DoubleToQuarterInRange(d.xy), quarter.DoubleToQuarterInRange(d.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter3 DoubleToQuarterInRangeAbs(double3 d)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(d), promiseAbsoluteAndInRange: true, elements: 3);
            }
            else
            {
                return new quarter3(quarter2.DoubleToQuarterInRangeAbs(d.xy), quarter.DoubleToQuarterInRangeAbs(d.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(quarter3 input) => (sbyte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(quarter3 input) => (byte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(quarter3 input) => (short3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(quarter3 input) => (ushort3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(quarter3 input) => (int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(quarter3 input) => (uint3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(quarter3 input) => (int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(quarter3 input) => (ulong3)(int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(quarter3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(quarter3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float3>(quarter.Vectorized.cvtpq_ps(input, elements: 3));
            }
            else
            {
                return new float3(input.x, input.y, input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float3 QuarterToFloatInRange(quarter3 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float3>(quarter.Vectorized.cvtpq_ps(q, promiseInRange: true, elements: 3));
            }
            else
            {
                return new float3(quarter.QuarterToFloatInRange(q.x), quarter.QuarterToFloatInRange(q.y), quarter.QuarterToFloatInRange(q.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float3 QuarterToFloatInRangeAbs(quarter3 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float3>(quarter.Vectorized.cvtpq_ps(q, promiseAbsoluteAndInRange: true, elements: 3));
            }
            else
            {
                return new float3(quarter.QuarterToFloatInRangeAbs(q.x), quarter.QuarterToFloatInRangeAbs(q.y), quarter.QuarterToFloatInRangeAbs(q.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(quarter3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToType<double3>(quarter.Vectorized.mm256_cvtpq_pd(input, elements: 3));
            }
            else
            {
                return new double3((quarter2)input.xy, (quarter)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double3 QuarterToDoubleInRange(quarter3 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToType<double3>(quarter.Vectorized.mm256_cvtpq_pd(q, promiseInRange: true, elements: 3));
            }
            else
            {
                return new double3(quarter2.QuarterToDoubleInRange(q.xy), quarter.QuarterToDoubleInRange(q.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double3 QuarterToDoubleInRangeAbs(quarter3 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToType<double3>(quarter.Vectorized.mm256_cvtpq_pd(q, promiseAbsoluteAndInRange: true, elements: 3));
            }
            else
            {
                return new double3(quarter2.QuarterToDoubleInRangeAbs(q.xy), quarter.QuarterToDoubleInRangeAbs(q.z));
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 3);

                return asquarter(asArray[index]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                asArray[index] = asbyte(value);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 operator - (quarter3 value)
        {
            return asquarter(asbyte(value) ^ new byte3(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, quarter3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool3>(quarter.Vectorized.cmpeq_pq(left, right, 3));
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, quarter right)
        {
            return left == (quarter3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter left, quarter3 right)
        {
            return (quarter3)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        public static bool3 operator == (half left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, half3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)right == 0f)))
            {
                return left == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (half3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)left == 0f)))
            {
                return right == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        public static bool3 operator == (float left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, float3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (float3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter3);
            }
            else
            {
                return (float3)left == (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter3);
            }
            else
            {
                return (double3)left == (double3)right;
            } 
        }

        public static bool3 operator == (double left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter3);
            }
            else
            {
                return (double3)left == (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (quarter3 left, double3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter3);
            }
            else
            {
                return (double3)left == (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (double3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter3);
            }
            else
            {
                return (double3)left == (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, quarter3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Xse.constexpr.IS_TRUE(left.x == 0f && left.y == 0f && left.z == 0f))
                {
                    return RegisterConversion.IsFalse8<bool3>(Sse2.cmpeq_epi8(Sse2.and_si128(right, new byte3(0b0111_1111)), Sse2.setzero_si128()));
                }
                else if (Xse.constexpr.IS_TRUE(right.x == 0f && right.y == 0f && right.z == 0f))
                {
                    return RegisterConversion.IsFalse8<bool3>(Sse2.cmpeq_epi8(Sse2.and_si128(left, new byte3(0b0111_1111)), Sse2.setzero_si128()));
                } 
                else
                {
                    return RegisterConversion.IsTrue8<bool3>(quarter.Vectorized.cmpneq_pq(left, right, 2));
                }
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, quarter right)
        {
            return left != (quarter3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter left, quarter3 right)
        {
            return (quarter3)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        public static bool3 operator != (half left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, half3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)right == 0f)))
            {
                return left != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (half3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)left == 0f)))
            {
                return right != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        public static bool3 operator != (float left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, float3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (float3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter3);
            }
            else
            {
                return (float3)left != (float3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter3);
            }
            else
            {
                return (double3)left != (double3)right;
            } 
        }

        public static bool3 operator != (double left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter3);
            }
            else
            {
                return (double3)left != (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (quarter3 left, double3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter3);
            }
            else
            {
                return (double3)left != (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (double3 left, quarter3 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter3);
            }
            else
            {
                return (double3)left != (double3)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter3 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.vcmpeq_pq(this, other, 3);
            }
            else
            {
                return this.x == other.x && this.y == other.y && this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v24(this);
            }
            else
            {
                return asArray[0] | (asArray[1] << 8) | (asArray[2] << 16);
            }
        }


        public override readonly string ToString() => $"quarter3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}