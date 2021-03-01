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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(ushort))]  [DebuggerTypeProxy(typeof(ushort2.DebuggerProxy))]
    unsafe public struct ushort2 : IEquatable<ushort2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public ushort x;
            public ushort y;

            public DebuggerProxy(ushort2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] private fixed ushort asArray[2];

        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;


        public static ushort2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort x, ushort y)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                this = Sse2.set_epi16(0, 0, 0, 0, 0, 0, (short)y, (short)x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort xy)
        {
            if (Sse2.IsSse2Supported)
            {
                this.x = this.y = xy;
            }
            else
            {
                this = Sse2.set1_epi16((short)xy);
            }
        }


        #region Shuffle
        public  ushort4 xxxx
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
                    return new ushort4(x, x, x, x);
                }
            }
        }
        public  ushort4 yxxx
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
                    return new ushort4(y, x, x, x);
                }
            }
        }
        public  ushort4 xyxx
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
                    return new ushort4(x, y, x, x);
                }
            }
        }
        public  ushort4 xxyx
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
                    return new ushort4(x, x, y, x);
                }
            }
        }
        public  ushort4 xxxy
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
                    return new ushort4(x, x, x, y);
                }
            }
        }
        public  ushort4 yyxx
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
                    return new ushort4(y, y, x, x);
                }
            }
        }
        public  ushort4 yxyx
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
                    return new ushort4(y, x, y, x);
                }
            }
        }
        public  ushort4 yxxy
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
                    return new ushort4(y, x, x, y);
                }
            }
        }
        public  ushort4 xyyx
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
                    return new ushort4(x, y, y, x);
                }
            }
        }
        public  ushort4 xyxy
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
                    return new ushort4(x, y, x, y);
                }
            }
        }
        public  ushort4 xxyy
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
                    return new ushort4(x, x, y, y);
                }
            }
        }
        public  ushort4 yyyx
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
                    return new ushort4(y, y, y, x);
                }
            }
        }
        public  ushort4 yyxy
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
                    return new ushort4(y, y, x, y);
                }
            }
        }
        public  ushort4 yxyy
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
                    return new ushort4(y, x, y, y);
                }
            }
        }
        public  ushort4 xyyy
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
                    return new ushort4(x, y, y, y);
                }
            }
        }
        public  ushort4 yyyy
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
                    return new ushort4(y, y, y, y);
                }
            }
        }

        public  ushort3 xxx
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
                    return new ushort3(x, x, x);
                }
            }
        }
        public  ushort3 yxx
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
                    return new ushort3(y, x, x);
                }
            }
        }
        public  ushort3 xyx
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
                    return new ushort3(x, y, x);
                }
            }
        }
        public  ushort3 xxy
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
                    return new ushort3(x, x, y);
                }
            }
        }
        public  ushort3 yyx
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
                    return new ushort3(y, y, x);
                }
            }
        }
        public  ushort3 yxy
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
                    return new ushort3(y, x, y);
                }
            }
        }
        public  ushort3 xyy
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
                    return new ushort3(x, y, y);
                }
            }
        }
        public  ushort3 yyy
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
                    return new ushort3(y, y, y);
                }
            }
        }

        public  ushort2 xx
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
                    return new ushort2(x, x);
                }
            }
        }
        public          ushort2 yx
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
                    return new ushort2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            { 
                this = value.yx; 
            }
        }
        public  ushort2 yy
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
                    return new ushort2(y, y);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static implicit operator v128(ushort2 input)
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
        public static implicit operator ushort2(v128 input) { int x = input.SInt0; return *(ushort2*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(ushort input) => new ushort2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(short2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(ushort2*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(int2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.Int2ToShort2(*(v128*)&input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(uint2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.Int2ToShort2(*(v128*)&input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(long2 input)
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
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(ulong2 input)
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
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(half2 input) => (ushort2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(float2 input) => (ushort2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(double2 input) => (ushort2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToInt(input);

                return *(int2*)&temp;
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToInt(input);

                return *(uint2*)&temp;
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.UShortToLong(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.UShortToLong(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(ushort2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ushort2 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToFloat(input); 
                
                return *(float2*)&temp;
            }
            else
            {
                return new float2((float)input.x, (float)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ushort2 input) => (int2)input;


        public ushort this[int index]
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
        public static ushort2 operator +(ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x + right.x), (ushort)(left.y + right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator -(ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x - right.x), (ushort)(left.y - right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x * right.x), (ushort)(left.y * right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_ushort(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x / right.x), (ushort)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_ushort(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x % right.x), (ushort)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort left, ushort2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((ushort8)((v128)left) * right);
            }
            else
            {
                return left * (ushort2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((ushort8)((v128)left) / right);
            }
            else
            {
                return left / (ushort2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)((ushort8)((v128)left) % right);
            }
            else
            {
                return left % (ushort2)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x & right.x), (ushort)(left.y & right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x | right.x), (ushort)(left.y | right.y));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ++ (ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort2((ushort)(x.x + 1), (ushort)(x.y + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator -- (ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort2((ushort)(x.x - 1), (ushort)(x.y - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ~ (ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort2((ushort)~x.x, (ushort)~x.y);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator << (ushort2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_short(x, n);
            }
            else
            {
                return new ushort2((ushort)(x.x << n), (ushort)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator >> (ushort2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_short(x, n);
            }
            else
            {
                return new ushort2((ushort)(x.x >> n), (ushort)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (ushort2 left, ushort2 right)
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
        public static bool2 operator < (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(right, left));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool2(left.x > right.x, left.y > right.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (ushort2 left, ushort2 right)
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
        public static bool2 operator <= (ushort2 left, ushort2 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.min_epu16(left, right), left));
            }
            else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (ushort2 left, ushort2 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.max_epu16(left, right), left));
            }
            else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(right, left));
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
        public  bool Equals(ushort2 other)
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

        public override  bool Equals(object obj) => Equals((ushort2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode()
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.extract_epi32(this, 0);
            }
            else
            {
                ushort2 temp = this;

                return *(int*)&temp;
            }
        }
    

        public override  string ToString() => $"ushort2({x}, {y})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"ushort2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}