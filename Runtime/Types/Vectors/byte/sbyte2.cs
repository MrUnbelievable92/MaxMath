using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(sbyte))]  [DebuggerTypeProxy(typeof(sbyte2.DebuggerProxy))]
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


        [FieldOffset(0)] private fixed sbyte asArray[2];

        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;


        public static sbyte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte x, sbyte y)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, y, x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = this.y = xy;
            }
            else
            {
                this = Sse2.set1_epi8(xy);
            }
        }


        #region Shuffle
        public sbyte4 xxxx
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, default(v128));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 _xxyy = Sse2.unpacklo_epi8(this, this);

                    return Sse2.unpacklo_epi16(_xxyy, _xxyy);
                }
                else
                {
                    return new sbyte4(x, x, x, x);
                }
            }
        }
        public sbyte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 0));
                }
                else
                {
                    return new sbyte4(y, x, x, x);
                }
            }
        }
        public sbyte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 0));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 _xxyy = Sse2.unpacklo_epi8(this, this);

                    return Sse2.unpacklo_epi16(this, _xxyy);
                }
                else
                {
                    return new sbyte4(x, y, x, x);
                }
            }
        }
        public sbyte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 0));
                }
                else
                {
                    return new sbyte4(x, x, y, x);
                }
            }
        }
        public sbyte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 _xxyy = Sse2.unpacklo_epi8(this, this);

                    return Sse2.unpacklo_epi16(_xxyy, this);
                }
                else
                {
                    return new sbyte4(x, x, x, y);
                }
            }
        }
        public sbyte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 0));
                }
                else
                {
                    return new sbyte4(y, y, x, x);
                }
            }
        }
        public sbyte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 0));
                }
                else
                {
                    return new sbyte4(y, x, y, x);
                }
            }
        }
        public sbyte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 1));
                }
                else
                {
                    return new sbyte4(y, x, x, y);
                }
            }
        }
        public sbyte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 0));
                }
                else
                {
                    return new sbyte4(x, y, y, x);
                }
            }
        }
        public sbyte4 xyxy
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
                    return new sbyte4(x, y, x, y);
                }
            }
        }
        public sbyte4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi8(this, this);
                }
                else
                {
                    return new sbyte4(x, x, y, y);
                }
            }
        }
        public sbyte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 0));
                }
                else
                {
                    return new sbyte4(y, y, y, x);
                }
            }
        }
        public sbyte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 1));
                }
                else
                {
                    return new sbyte4(y, y, x, y);
                }
            }
        }
        public sbyte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 1));
                }
                else
                {
                    return new sbyte4(y, x, y, y);
                }
            }
        }
        public sbyte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 1));
                }
                else
                {
                    return new sbyte4(x, y, y, y);
                }
            }
        }
        public sbyte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 1));
                }
                else
                {
                    return new sbyte4(y, y, y, y);
                }
            }
        }

        public sbyte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, default(v128));
                }
                else
                {
                    return new sbyte3(x, x, x);
                }
            }
        }
        public sbyte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 3));
                }
                else
                {
                    return new sbyte3(y, x, x);
                }
            }
        }
        public sbyte3 xyx
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
                    return new sbyte3(x, y, x);
                }
            }
        }
        public sbyte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi8(this, this);
                }
                else
                {
                    return new sbyte3(x, x, y);
                }
            }
        }
        public sbyte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 3));
                }
                else
                {
                    return new sbyte3(y, y, x);
                }
            }
        }
        public sbyte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 3));
                }
                else
                {
                    return new sbyte3(y, x, y);
                }
            }
        }
        public sbyte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 3));
                }
                else
                {
                    return new sbyte3(x, y, y);
                }
            }
        }
        public sbyte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 3));
                }
                else
                {
                    return new sbyte3(y, y, y);
                }
            }
        }

        public sbyte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi8(this, this);
                }
                else
                {
                    return new sbyte2(x, x);
                }
            }
        }
        public          sbyte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 3));
                }
                else
                {
                    return new sbyte2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            { 
                this = value.yx; 
            }
        }
        public sbyte2 yy
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get 
			{
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 3));
                }
                else
                {
                    return new sbyte2(y, y);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input) => new v128(*(ushort*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                short x = input.SShort0;

                return *(sbyte2*)&x;
            }
            else
            {
                int x = input.SInt0;

                return *(sbyte2*)&x;
            }
        }

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
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Short4ToByte4(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Short2To_S_Byte2_SSE2(input);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ushort2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Short4ToByte4(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Short2To_S_Byte2_SSE2(input);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(int2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(UnityMathematicsLink.Tov128(input));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int2To_S_Byte2_SSE2(UnityMathematicsLink.Tov128(input));
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(uint2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(UnityMathematicsLink.Tov128(input));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int2To_S_Byte2_SSE2(UnityMathematicsLink.Tov128(input));
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(long2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Long2ToByte2(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Long2To_S_Byte2_SSE2(input);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ulong2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Long2ToByte2(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Long2To_S_Byte2_SSE2(input);
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
                return Cast.SByteToShort(input);
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
                return Cast.SByteToShort(input);
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
                v128 temp = Cast.SByteToInt(input);

                return *(int2*)&temp;
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
                v128 temp = Cast.SByteToInt(input);

                return *(uint2*)&temp;
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
                return Cast.SByteToLong(input);
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
                return Cast.SByteToLong(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(sbyte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(sbyte2 input) => (double2)(int2)input;

        
        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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
                if (Constant.IsConstantExpression(right))
                {
                    bool sameValue = maxmath.all_eq(right);

                    if (sameValue)
                    {
                        return left * right.x;
                    }
                    else if (math.all(right != 0) && math.all(maxmath.ispow2(right)))
                    {
                        return maxmath.shl(left, maxmath.tzcnt(right));
                    }
                }
                
                return (sbyte2)((short2)left * (short2)right);
            }
            else
            {
                return new sbyte2((sbyte)(left.x * right.x), (sbyte)(left.y * right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte2 right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if (maxmath.all_eq(right))
                {
                    return Operator.Constant.vdiv_sbyte(left, right.x, 2);
                }
            }

            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(left, right);
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
                return Operator.vrem_sbyte(left, right);
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
                    return (v128)((sbyte16)((v128)left) * right);
                }
            }
            
            return left * (sbyte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 left, sbyte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return Operator.Constant.vdiv_sbyte(left, right, 2);
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
                    return (v128)((sbyte16)((v128)left) % right);
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
                return Sse2.sub_epi8(default(v128), x);
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
                return Sse2.sub_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
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
                return Sse2.add_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
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
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
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
                return Operator.shl_byte(x, n);
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
                return (sbyte2)((short2)x >> n);
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
                v128 cvt = ConvertToBool.IsTrue8(Sse2.cmpeq_epi8(left, right));

                return *(bool2*)&cvt;
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
                v128 cvt = ConvertToBool.IsTrue8(Sse2.cmpgt_epi8(right, left));

                return *(bool2*)&cvt;
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
                v128 cvt = ConvertToBool.IsTrue8(Sse2.cmpgt_epi8(left, right));

                return *(bool2*)&cvt;
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
                v128 cvt = ConvertToBool.IsFalse8(Sse2.cmpeq_epi8(left, right));

                return *(bool2*)&cvt;
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
                v128 cvt = ConvertToBool.IsFalse8(Sse2.cmpgt_epi8(left, right));

                return *(bool2*)&cvt;
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
                v128 cvt = ConvertToBool.IsFalse8(Sse2.cmpgt_epi8(right, left));

                return *(bool2*)&cvt;
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte2 other)
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

        public override bool Equals(object obj) => Equals((sbyte2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
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


        public override string ToString() => $"sbyte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}