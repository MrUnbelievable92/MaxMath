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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(byte))]  [DebuggerTypeProxy(typeof(byte2.DebuggerProxy))]
    unsafe public struct byte2 : IEquatable<byte2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public byte x;
            public byte y;

            public DebuggerProxy(byte2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[2];

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;


        public static byte2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte x, byte y)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)y, (sbyte)x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte xy)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = this.y = xy;
            }
            else
            {
                this = Sse2.set1_epi8((sbyte)xy);
            }
        }


        #region Shuffle
        public byte4 xxxx
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
                    return new byte4(x, x, x, x);
                }
            }
        }
        public byte4 yxxx
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
                    return new byte4(y, x, x, x);
                }
            }
        }
        public byte4 xyxx
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
                    return new byte4(x, y, x, x);
                }
            }
        }
        public byte4 xxyx
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
                    return new byte4(x, x, y, x);
                }
            }
        }
        public byte4 xxxy
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
                    return new byte4(x, x, x, y);
                }
            }
        }
        public byte4 yyxx
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
                    return new byte4(y, y, x, x);
                }
            }
        }
        public byte4 yxyx
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
                    return new byte4(y, x, y, x);
                }
            }
        }
        public byte4 yxxy
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
                    return new byte4(y, x, x, y);
                }
            }
        }
        public byte4 xyyx
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
                    return new byte4(x, y, y, x);
                }
            }
        }
        public byte4 xyxy
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
                    return new byte4(x, y, x, y);
                }
            }
        }
        public byte4 xxyy
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
                    return new byte4(x, x, y, y);
                }
            }
        }
        public byte4 yyyx
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
                    return new byte4(y, y, y, x);
                }
            }
        }
        public byte4 yyxy
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
                    return new byte4(y, y, x, y);
                }
            }
        }
        public byte4 yxyy
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
                    return new byte4(y, x, y, y);
                }
            }
        }
        public byte4 xyyy
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
                    return new byte4(x, y, y, y);
                }
            }
        }
        public byte4 yyyy
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
                    return new byte4(y, y, y, y);
                }
            }
        }

        public byte3 xxx
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
                    return new byte3(x, x, x);
                }
            }
        }
        public byte3 yxx
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
                    return new byte3(y, x, x);
                }
            }
        }
        public byte3 xyx
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
                    return new byte3(x, y, x);
                }
            }
        }
        public byte3 xxy
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
                    return new byte3(x, x, y);
                }
            }
        }
        public byte3 yyx
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
                    return new byte3(y, y, x);
                }
            }
        }
        public byte3 yxy
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
                    return new byte3(y, x, y);
                }
            }
        }
        public byte3 xyy
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
                    return new byte3(x, y, y);
                }
            }
        }
        public byte3 yyy
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
                    return new byte3(y, y, y);
                }
            }
        }

        public byte2 xx
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
                    return new byte2(x, x);
                }
            }
        }
        public          byte2 yx
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
                    return new byte2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            { 
                this = value.yx; 
            }
        }
        public byte2 yy
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
                    return new byte2(y, y);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte2 input) => new v128(*(ushort*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(v128 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                short x = input.SShort0;

                return *(byte2*)&x;
            }
            else
            {
                int x = input.SInt0;

                return *(byte2*)&x;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(byte input) => new byte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(sbyte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(short2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ushort2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(int2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(uint2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(long2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ulong2 input)
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
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(half2 input) => (byte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(float2 input) => (byte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(double2 input) => (byte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.ByteToInt(input);

                return *(int2*)&temp;
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.ByteToInt(input);

                return *(uint2*)&temp;
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToLong(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(byte2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToLong(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(byte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(byte2 input)
        {
            return (float2)(int2)input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(byte2 input) => (double2)(int2)input;


        public byte this[int index]
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
        public static byte2 operator + (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x + right.x), (byte)(left.y + right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte2((byte)(left.x - right.x), (byte)(left.y - right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte2 right)
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
  
                return (byte2)((ushort2)left * (ushort2)right);
            }
            else
            {
                return new byte2((byte)(left.x * right.x), (byte)(left.y * right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte2 right)
        {
            if (Constant.IsConstantExpression(right))
            {
Assert.IsTrue(math.all(right != 0));

                bool sameValue = maxmath.all_eq(right);

                if (!sameValue && math.all(maxmath.ispow2(right)))
                {
                    return maxmath.shrl(left, maxmath.tzcnt(right));    
                } 
                else if (sameValue)
                {
                    return Operator.Constant.vdiv_byte(left, right.x);
                }
            }

            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else
            {
                return new byte2((byte)(left.x / right.x), (byte)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else
            {
                return new byte2((byte)(left.x % right.x), (byte)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte left, byte2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((byte16)((v128)left) * right);
                }
            }
            
            return left * (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return Operator.Constant.vdiv_byte(left, right);
            }

            return left / (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((byte16)((v128)left) % right);
                }
            }

            return left % (byte2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x & right.x), (byte)(left.y & right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x | right.x), (byte)(left.y | right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte2((byte)(left.x ^ right.x), (byte)(left.y ^ right.y));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ++ (byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte2((byte)(x.x + 1), (byte)(x.y + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator -- (byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte2((byte)(x.x - 1), (byte)(x.y - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ~ (byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte2((byte)~x.x, (byte)~x.y);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator << (byte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte2((byte)(x.x << n), (byte)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator >> (byte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte2((byte)(x.x >> n), (byte)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (byte2 left, byte2 right)
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
        public static bool2 operator < (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cvt = ConvertToBool.IsTrue8(Operator.greater_mask_byte(right, left));

                return *(bool2*)&cvt;
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cvt = ConvertToBool.IsTrue8(Operator.greater_mask_byte(left, right));

                return *(bool2*)&cvt;
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (byte2 left, byte2 right)
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
        public static bool2 operator <= (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cvt = ConvertToBool.IsTrue8(Sse2.cmpeq_epi8(Sse2.min_epu8(left, right), left));

                return *(bool2*)&cvt;
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 cvt = ConvertToBool.IsTrue8(Sse2.cmpeq_epi8(Sse2.max_epu8(left, right), left));

                return *(bool2*)&cvt;
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }

    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte2 other)
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

        public override bool Equals(object obj) => Equals((byte2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse.IsSseSupported)
            {
                return ((v128)this).UShort0;
            }
            else
            {
                byte2 temp = this;

                return *(ushort*)&temp;
            }
        }


        public override string ToString() => $"byte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}