using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(ushort))]  
    [DebuggerTypeProxy(typeof(half8.DebuggerProxy))]
    unsafe public struct half8 : IEquatable<half8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public half x0;
            public half x1;
            public half x2;
            public half x3;
            public half x4;
            public half x5;
            public half x6;
            public half x7;

            public DebuggerProxy(half8 v)
            {
                x0 = v.x0;
                x1 = v.x1;
                x2 = v.x2;
                x3 = v.x3;
                x4 = v.x4;
                x5 = v.x5;
                x6 = v.x6;
                x7 = v.x7;
            }
        }


        [FieldOffset(0)]  private fixed ushort asArray[8];
 
        [FieldOffset(0)]  public half x0;
        [FieldOffset(2)]  public half x1;
        [FieldOffset(4)]  public half x2;
        [FieldOffset(6)]  public half x3;
        [FieldOffset(8)]  public half x4;
        [FieldOffset(10)] public half x5;
        [FieldOffset(12)] public half x6;
        [FieldOffset(14)] public half x7;


        public static half8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0, half x1, half x2, half x3, half x4, half x5, half x6, half x7)
        {
            this = maxmath.ashalf(new ushort8(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0x8)
        {
            this = maxmath.ashalf(new ushort8(x0x8.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half2 x45, half2 x67)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x01), maxmath.asushort(x23), maxmath.asushort(x45), maxmath.asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half3 x234, half3 x567)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x01), maxmath.asushort(x234), maxmath.asushort(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half2 x34, half3 x567)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x012), maxmath.asushort(x34), maxmath.asushort(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half3 x345, half2 x67)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x012), maxmath.asushort(x345), maxmath.asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half2 x45, half2 x67)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x0123), maxmath.asushort(x45), maxmath.asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half4 x2345, half2 x67)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x01), maxmath.asushort(x2345), maxmath.asushort(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half4 x4567)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x01), maxmath.asushort(x23), maxmath.asushort(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half4 x4567)
        {
            this = maxmath.ashalf(new ushort8(maxmath.asushort(x0123), maxmath.asushort(x4567)));
        }


        public half4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v4_0 = maxmath.asushort(value); this = maxmath.ashalf(temp); } } 
        public half4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v4_1 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v4_2 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v4_3 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v4_4 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  

        public half3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_0 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_1 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_2 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_3 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_4 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v3_5 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  

        public half2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_0 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_1 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_2 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_3 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_4 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }  
        public half2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_5 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }
        public half2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.ashalf(maxmath.asushort(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort8 temp = maxmath.asushort(this); temp.v2_6 = maxmath.asushort(value); this = maxmath.ashalf(temp); } }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(half8 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(v128 input) => RegisterConversion.ToType<half8>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(half input) => new half8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(float8 input)
        {
            if (F16C.IsF16CSupported)
            {
                return F16C.mm256_cvtps_ph(input, (int)RoundingMode.FROUND_NINT_NOEXC);
            }
            else
            {
                return new half8((half4)input.v4_0, (half4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(half8 input)
        {
            //if (F16C.IsF16CSupported)
            //{
            //    return F16C.mm256_cvtph_ps(input);
            //}
            //else
            //{
                return new float8((float4)input.v4_0, (float4)input.v4_4);
            //}
        }


        public half this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                return maxmath.ashalf(asArray[index]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                asArray[index] = maxmath.asushort(value);
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (half8 left, half8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16<bool8>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.v4_0 == right.v4_0, left.v4_4 == right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (half8 left, half8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16<bool8>(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.v4_0 != right.v4_0, left.v4_4 != right.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return ulong.MaxValue == Sse2.cmpeq_epi16(this, other).ULong0;
            }
            else
            {
                return this.v4_0.Equals(other.v4_0) & this.v4_4.Equals(other.v4_4);
            }
        }

        public override readonly bool Equals(object obj) => obj is half8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                half8 temp = this;
                return (*(long*)&temp ^ (*((long*)&temp + 1))).GetHashCode();
            }
        }


        public override readonly string ToString() => $"half8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"half8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}