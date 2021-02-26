using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(short))]  [DebuggerTypeProxy(typeof(short2.DebuggerProxy))]
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
                this.x = x;
                this.y = y;
            }
            else
            {
                this = Sse2.set_epi16(0, 0, 0, 0, 0, 0, y, x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short xy)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = this.y = xy;
            }
            else
            {
                this = Sse2.set1_epi16(xy);
            }
        }


        #region Shuffle
        public  short4 xxxx
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
        public  short4 yxxx
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
        public  short4 xyxx
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
        public  short4 xxyx
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
        public  short4 xxxy
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
        public  short4 yyxx
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
        public  short4 yxyx
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
        public  short4 yxxy
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
        public  short4 xyyx
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
        public  short4 xyxy
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
        public  short4 xxyy
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
        public  short4 yyyx
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
        public  short4 yyxy
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
        public  short4 yxyy
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
        public  short4 xyyy
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
        public  short4 yyyy
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

        public  short3 xxx
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
        public  short3 yxx
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
        public  short3 xyx
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
        public  short3 xxy
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
        public  short3 yyx
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
        public  short3 yxy
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
        public  short3 xyy
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
        public  short3 yyy
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

        public  short2 xx
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
             get
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
        public  short2 yy
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
        public static implicit operator v128(short2 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.insert_epi32(default(v128), *(int*)&input, 0);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.set_epi32(0, 0, 0, *(int*)&input);
            }
            else
            {
                return new v128(*(int*)&input, 0, 0, 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(v128 input) { int x = input.SInt0; return *(short2*)&x; }

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
                return Cast.Int2ToShort2(*(v128*)&input);
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
                return Cast.Int2ToShort2(*(v128*)&input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(long2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Long2ToShort2(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Long2To_U_Short2_SSE2(input);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ulong2 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Long2ToShort2(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Long2To_U_Short2_SSE2(input);
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
                v128 temp = Cast.ShortToInt(input);

                return *(int2*)&temp;
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
                v128 temp = Cast.ShortToInt(input);

                return *(uint2*)&temp;
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
                return Cast.ShortToLong(input);
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
                return Cast.ShortToLong(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(short2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(short2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(short2 input) => (double2)(int2)input;


        public short this[int index]
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
                return Operator.vdiv_short(left, right);
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
                return Operator.vrem_short(left, right);
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
                return (v128)((short8)((v128)left) * right);
            }
            else
            {
                return left * (short2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((short8)((v128)left) / right);
            }
            else
            {
                return left / (short2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((short8)((v128)left) % right);
            }
            else
            {
                return left % (short2)right;
            }
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
                return Sse2.sub_epi16(default(v128), x);
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
                return Sse2.add_epi16(x, new short2(1));
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
                return Sse2.sub_epi16(x, new short2(1));
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
                return Sse2.andnot_si128(x, new short2(-1));
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
                return Operator.shl_short(x, n);
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
                return Operator.shra_short(x, n);
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
                return TestIsTrue(Sse2.cmpeq_epi16(left, right));
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
                return TestIsTrue(Sse2.cmpgt_epi16(right, left));
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
                return TestIsTrue(Sse2.cmpgt_epi16(left, right));
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
                return TestIsFalse(Sse2.cmpeq_epi16(left, right));
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
                return TestIsFalse(Sse2.cmpgt_epi16(left, right));
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
                return TestIsFalse(Sse2.cmpgt_epi16(right, left));
            }
            else
            {
                return new bool2(left.x >= right.x, left.y >= right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            input = (v128)((byte8)(-(short8)input));

            return *(bool2*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                input = Sse2.andnot_si128((byte2)(ushort2)input, new ushort2(0x0101));

                return *(bool2*)&input;
            }
            else throw new CPUFeatureCheckException();
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(short2 other)
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

        public override  bool Equals(object obj) => Equals((short2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode()
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.extract_epi32(this, 0);
            }
            else
            {
                short2 temp = this;

                return *(int*)&temp;
            }
        }


        public override  string ToString() => $"short2({x}, {y})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"short2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}