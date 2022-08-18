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


        [FieldOffset(0)] private fixed short asArray[2];

        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;


        public static short2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short x, short y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y))
                {
                    this = Sse2.cvtsi32_si128((int)bitfield(x, y));
                }
                else
                {
				    this = Sse2.insert_epi16(Sse2.cvtsi32_si128(x), y, 1);
                }
            }
            else
            {
                this.x = x;
                this.y = y;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short xy)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(xy))
                {
                    this = Sse2.cvtsi32_si128((int)bitfield(xy, xy));
                }
                else
                {
				    this = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128((ushort)xy), Sse.SHUFFLE(0, 0, 0, 0));
                }
            }
            else
            {
                this = Sse2.set1_epi16(xy);
            }
        }


        #region Shuffle
        public readonly short4 xxxx
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new short4(x, x, x, x);
                }
            }
        }
        public readonly short4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
                }
                else
                {
                    return new short4(y, x, x, x);
                }
            }
        }
        public readonly short4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
                }
                else
                {
                    return new short4(x, y, x, x);
                }
            }
        }
        public readonly short4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
                }
                else
                {
                    return new short4(x, x, y, x);
                }
            }
        }
        public readonly short4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
                }
                else
                {
                    return new short4(x, x, x, y);
                }
            }
        }
        public readonly short4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
                }
                else
                {
                    return new short4(y, y, x, x);
                }
            }
        }
        public readonly short4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
                }
                else
                {
                    return new short4(y, x, y, x);
                }
            }
        }
        public readonly short4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
                }
                else
                {
                    return new short4(y, x, x, y);
                }
            }
        }
        public readonly short4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
                }
                else
                {
                    return new short4(x, y, y, x);
                }
            }
        }
        public readonly short4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new short4(x, y, x, y);
                }
            }
        }
        public readonly short4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
                }
                else
                {
                    return new short4(x, x, y, y);
                }
            }
        }
        public readonly short4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
                }
                else
                {
                    return new short4(y, y, y, x);
                }
            }
        }
        public readonly short4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
                }
                else
                {
                    return new short4(y, y, x, y);
                }
            }
        }
        public readonly short4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
                }
                else
                {
                    return new short4(y, x, y, y);
                }
            }
        }
        public readonly short4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
                }
                else
                {
                    return new short4(x, y, y, y);
                }
            }
        }
        public readonly short4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
                }
                else
                {
                    return new short4(y, y, y, y);
                }
            }
        }

        public readonly short3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new short3(x, x, x);
                }
            }
        }
        public readonly short3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
                }
                else
                {
                    return new short3(y, x, x);
                }
            }
        }
        public readonly short3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new short3(x, y, x);
                }
            }
        }
        public readonly short3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
                }
                else
                {
                    return new short3(x, x, y);
                }
            }
        }
        public readonly short3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
                }
                else
                {
                    return new short3(y, y, x);
                }
            }
        }
        public readonly short3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
                }
                else
                {
                    return new short3(y, x, y);
                }
            }
        }
        public readonly short3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
                }
                else
                {
                    return new short3(x, y, y);
                }
            }
        }
        public readonly short3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
                }
                else
                {
                    return new short3(y, y, y);
                }
            }
        }

        public readonly short2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new short2(x, x);
                }
            }
        }
        public          short2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
                }
                else
                {
                    return new short2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            { 
                this = value.yx; 
            }
        }
        public readonly short2 yy
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
                }
                else
                {
                    return new short2(y, y);
                }
            }
        }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short2 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(v128 input) => RegisterConversion.ToType<short2>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(short input) => new short2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(short2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(int2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 2);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(long2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi64_epi16(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ulong2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi64_epi16(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(half2 input) => (short2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(float2 input) => (short2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(double2 input) => (short2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(short2 input)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<float2>(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<double2>(Xse.cvtepi16_pd(input));
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
        public static short2 operator + (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new short2((short)(left.x + right.x), (short)(left.y + right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new short2((short)(left.x - right.x), (short)(left.y - right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new short2((short)(left.x * right.x), (short)(left.y * right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((short8)((v128)left) * right);
                }
            }

            return left * (short2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi16(left, right, 2);
                }
            }
                
            return left / (short2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi16(left, right, 2);
                }
            }
                
            return left % (short2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new short2((short)(left.x & right.x), (short)(left.y & right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new short2((short)(left.x | right.x), (short)(left.y | right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new short2((short)(left.x ^ right.x), (short)(left.y ^ right.y));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new short2((short)(x.x - 1), (short)(x.y - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ~ (short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new short2((short)~x.x, (short)~x.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator << (short2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi16(x, n);
            }
            else
            {
                return new short2((short)(x.x << n), (short)(x.y << n));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator >> (short2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi16(x, n);
            }
            else
            {
                return new short2((short)(x.x >> n), (short)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool2>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool2>(Xse.cmplt_epi16(left, right));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool2>(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool2>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool2>(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (short2 left, short2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool2>(Xse.cmplt_epi16(left, right));
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return uint.MaxValue == Sse2.cmpeq_epi8(this, other).UInt0;
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        } 

        public override readonly bool Equals(object obj) => obj is short2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cvtsi128_si32(this);
            }
            else
            {
                short2 temp = this;

                return *(int*)&temp;
            }
        }


        public override readonly string ToString() => $"short2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}