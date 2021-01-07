using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 16)]
    unsafe public struct half8 : IEquatable<half8>, IFormattable
    {
        [NoAlias] public half x0;
        [NoAlias] public half x1;
        [NoAlias] public half x2;
        [NoAlias] public half x3;
        [NoAlias] public half x4;
        [NoAlias] public half x5;
        [NoAlias] public half x6;
        [NoAlias] public half x7;


        public static half8 zero => default(half8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0, half x1, half x2, half x3, half x4, half x5, half x6, half x7)
        {
            this = new half8 { x0 = x0, x1 = x1, x2 = x2, x3 = x3, x4 = x4, x5 = x5, x6 = x6, x7 = x7 };
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half x0x8)
        {
            v128 broadcast = Sse2.set1_epi16((short)x0x8.value);

            this = *(half8*)&broadcast;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half2 x45, half2 x67)
        {
            half8 newOne = *(half8*)&x01;
            *(half2*)&newOne.x2 = x23;
            *(half2*)&newOne.x4 = x45;
            *(half2*)&newOne.x6 = x67;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half3 x234, half3 x567)
        {
            half8 newOne = *(half8*)&x01;
            *(half3*)&newOne.x2 = x234;
            *(half3*)&newOne.x5 = x567;

            this = newOne;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half2 x34, half3 x567)
        {
            half8 newOne = *(half8*)&x012;
            *(half2*)&newOne.x3 = x34;
            *(half3*)&newOne.x5 = x567;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half3 x012, half3 x345, half2 x67)
        {
            half8 newOne = *(half8*)&x012;
            *(half3*)&newOne.x3 = x345;
            *(half2*)&newOne.x6 = x67;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half2 x45, half2 x67)
        {
            half8 newOne = *(half8*)&x0123;
            *(half2*)&newOne.x4 = x45;
            *(half2*)&newOne.x6 = x67;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half4 x2345, half2 x67)
        {
            half8 newOne = *(half8*)&x01;
            *(half4*)&newOne.x2 = x2345;
            *(half2*)&newOne.x6 = x67;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half2 x01, half2 x23, half4 x4567)
        {
            half8 newOne = *(half8*)&x01;
            *(half2*)&newOne.x2 = x23;
            *(half4*)&newOne.x4 = x4567;

            this = newOne;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half8(half4 x0123, half4 x4567)
        {
            half8 newOne = *(half8*)&x0123;
            *(half4*)&newOne.x4 = x4567;

            this = newOne;

            // This works in managed C# but who knows what happens to this 
            // this = *(half8*)&x0123;
        }


        public half4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this)    { return *(half4*)ptr; } } set { fixed (void* ptr = &this)    { *(half4*)ptr = value; } } } 
        public half4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x1) { return *(half4*)ptr; } } set { fixed (void* ptr = &this.x1) { *(half4*)ptr = value; } } }  
        public half4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x2) { return *(half4*)ptr; } } set { fixed (void* ptr = &this.x2) { *(half4*)ptr = value; } } }  
        public half4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x3) { return *(half4*)ptr; } } set { fixed (void* ptr = &this.x3) { *(half4*)ptr = value; } } }  
        public half4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x4) { return *(half4*)ptr; } } set { fixed (void* ptr = &this.x4) { *(half4*)ptr = value; } } }  
                                                                                             
        public half3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this)    { return *(half3*)ptr; } } set { fixed (void* ptr = &this)    { *(half3*)ptr = value; } } }  
        public half3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x1) { return *(half3*)ptr; } } set { fixed (void* ptr = &this.x1) { *(half3*)ptr = value; } } }  
        public half3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x2) { return *(half3*)ptr; } } set { fixed (void* ptr = &this.x2) { *(half3*)ptr = value; } } }  
        public half3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x3) { return *(half3*)ptr; } } set { fixed (void* ptr = &this.x3) { *(half3*)ptr = value; } } }  
        public half3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x4) { return *(half3*)ptr; } } set { fixed (void* ptr = &this.x4) { *(half3*)ptr = value; } } }  
        public half3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x5) { return *(half3*)ptr; } } set { fixed (void* ptr = &this.x5) { *(half3*)ptr = value; } } }  
                                                                                                                             
        public half2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this)    { return *(half2*)ptr; } } set { fixed (void* ptr = &this)    { *(half2*)ptr = value; } } }  
        public half2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x1) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x1) { *(half2*)ptr = value; } } }  
        public half2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x2) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x2) { *(half2*)ptr = value; } } }  
        public half2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x3) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x3) { *(half2*)ptr = value; } } }  
        public half2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x4) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x4) { *(half2*)ptr = value; } } }  
        public half2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x5) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x5) { *(half2*)ptr = value; } } }  
        public half2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed (void* ptr = &this.x6) { return *(half2*)ptr; } } set { fixed (void* ptr = &this.x6) { *(half2*)ptr = value; } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse2.load(u)_[...].
        public static implicit operator v128(half8 input) => new v128(input.x0.value, input.x1.value, input.x2.value, input.x3.value, input.x4.value, input.x5.value, input.x6.value, input.x7.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator half8(v128 input) => new half8 { x0 = new half { value = input.UShort0 }, x1 = new half { value = input.UShort1 }, x2 = new half { value = input.UShort2 }, x3 = new half { value = input.UShort3 }, x4 = new half { value = input.UShort4 }, x5 = new half { value = input.UShort5 }, x6 = new half { value = input.UShort6 }, x7 = new half { value = input.UShort7 } };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(half input) => new half8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(float8 input) => F16C.mm256_cvtps_ph(input, (int)RoundingMode.FROUND_NINT_NOEXC);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(half8 input) => F16C.mm256_cvtph_ps(input);


        public half this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((half*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((half*)ptr)[index] = value;
                }
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (half8 left, half8 right) => TestIsTrue(Sse2.cmpeq_epi16(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (half8 left, half8 right) => TestIsFalse(Sse2.cmpeq_epi16(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input)
        {
            return Sse2.and_si128((byte8)(ushort8)input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128((byte8)(ushort8)input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(half8 other) => maxmath.bitmask32(8 * sizeof(half)) == Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other));

        public override bool Equals(object obj) => Equals((half8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v128(this);


        public override string ToString() => $"half8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"half8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}