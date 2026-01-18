using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(ushort))]
    [DebuggerTypeProxy(typeof(half16.DebuggerProxy))]
    unsafe public struct half16 : IEquatable<half16>, IFormattable
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
            public half x8;
            public half x9;
            public half x10;
            public half x11;
            public half x12;
            public half x13;
            public half x14;
            public half x15;

            public DebuggerProxy(half16 v)
            {
                x0  = v.x0;
                x1  = v.x1;
                x2  = v.x2;
                x3  = v.x3;
                x4  = v.x4;
                x5  = v.x5;
                x6  = v.x6;
                x7  = v.x7;
                x8  = v.x8;
                x9  = v.x9;
                x10 = v.x10;
                x11 = v.x11;
                x12 = v.x12;
                x13 = v.x13;
                x14 = v.x14;
                x15 = v.x15;
            }
        }


        [FieldOffset(0)]  internal half8 _v8_0;
        [FieldOffset(16)] internal half8 _v8_8;

        [FieldOffset(0)]  public half x0;
        [FieldOffset(2)]  public half x1;
        [FieldOffset(4)]  public half x2;
        [FieldOffset(6)]  public half x3;
        [FieldOffset(8)]  public half x4;
        [FieldOffset(10)] public half x5;
        [FieldOffset(12)] public half x6;
        [FieldOffset(14)] public half x7;
        [FieldOffset(16)] public half x8;
        [FieldOffset(18)] public half x9;
        [FieldOffset(20)] public half x10;
        [FieldOffset(22)] public half x11;
        [FieldOffset(24)] public half x12;
        [FieldOffset(26)] public half x13;
        [FieldOffset(28)] public half x14;
        [FieldOffset(30)] public half x15;


        public static half16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half x0, half x1, half x2, half x3, half x4, half x5, half x6, half x7, half x8, half x9, half x10, half x11, half x12, half x13, half x14, half x15)
        {
            this = ashalf(new ushort16(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value, x8.value, x9.value, x10.value, x11.value, x12.value, x13.value, x14.value, x15.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half x0x16)
        {
            this = ashalf(new ushort16(x0x16.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half2 x01, half2 x23, half2 x45, half2 x67, half2 x89, half2 x10_11, half2 x12_13, half2 x14_15)
        {
            this = ashalf(new ushort16(asushort(x01), asushort(x23), asushort(x45), asushort(x67), asushort(x89), asushort(x10_11), asushort(x12_13), asushort(x14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half4 x0123, half4 x4567, half4 x8_9_10_11, half4 x12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x0123), asushort(x4567), asushort(x8_9_10_11), asushort(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half4 x0123, half3 x456, half3 x789, half3 x10_11_12, half3 x13_14_15)
        {
            this = ashalf(new ushort16(asushort(x0123), asushort(x456), asushort(x789), asushort(x10_11_12), asushort(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half3 x012, half4 x3456, half3 x789, half3 x10_11_12, half3 x13_14_15)
        {
            this = ashalf(new ushort16(asushort(x012), asushort(x3456), asushort(x789), asushort(x10_11_12), asushort(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half3 x012, half3 x345, half4 x6789, half3 x10_11_12, half3 x13_14_15)
        {
            this = ashalf(new ushort16(asushort(x012), asushort(x345), asushort(x6789), asushort(x10_11_12), asushort(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half3 x012, half3 x345, half3 x678, half4 x9_10_11_12, half3 x13_14_15)
        {
            this = ashalf(new ushort16(asushort(x012), asushort(x345), asushort(x678), asushort(x9_10_11_12), asushort(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half3 x012, half3 x345, half3 x678, half3 x9_10_11, half4 x12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x012), asushort(x345), asushort(x678), asushort(x9_10_11), asushort(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half8 x01234567, half4 x8_9_10_11, half4 x12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x01234567), asushort(x8_9_10_11), asushort(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half4 x0123, half8 x4_5_6_7_8_9_10_11, half4 x12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x0123), asushort(x4_5_6_7_8_9_10_11), asushort(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half4 x0123, half4 x4567, half8 x8_9_10_11_12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x0123), asushort(x4567), asushort(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half16(half8 x01234567, half8 x8_9_10_11_12_13_14_15)
        {
            this = ashalf(new ushort16(asushort(x01234567), asushort(x8_9_10_11_12_13_14_15)));
        }


        #region Shuffle
        public half8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_0 = asushort(value); this = ashalf(temp); } }
        public half8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_1 = asushort(value); this = ashalf(temp); } }
        public half8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_2 = asushort(value); this = ashalf(temp); } }
        public half8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_3 = asushort(value); this = ashalf(temp); } }
        public half8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_4 = asushort(value); this = ashalf(temp); } }
        public half8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_5 = asushort(value); this = ashalf(temp); } }
        public half8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_6 = asushort(value); this = ashalf(temp); } }
        public half8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_7); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_7 = asushort(value); this = ashalf(temp); } }
        public half8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v8_8); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v8_8 = asushort(value); this = ashalf(temp); } }

        public half4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_0  = asushort(value); this = ashalf(temp); } }
        public half4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_1  = asushort(value); this = ashalf(temp); } }
        public half4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_2  = asushort(value); this = ashalf(temp); } }
        public half4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_3  = asushort(value); this = ashalf(temp); } }
        public half4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_4  = asushort(value); this = ashalf(temp); } }
        public half4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_5  = asushort(value); this = ashalf(temp); } }
        public half4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_6  = asushort(value); this = ashalf(temp); } }
        public half4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_7  = asushort(value); this = ashalf(temp); } }
        public half4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_8  = asushort(value); this = ashalf(temp); } }
        public half4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_9  = asushort(value); this = ashalf(temp); } }
        public half4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_10 = asushort(value); this = ashalf(temp); } }
        public half4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_11 = asushort(value); this = ashalf(temp); } }
        public half4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v4_12 = asushort(value); this = ashalf(temp); } }

        public half3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_0  = asushort(value); this = ashalf(temp); } }
        public half3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_1  = asushort(value); this = ashalf(temp); } }
        public half3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_2  = asushort(value); this = ashalf(temp); } }
        public half3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_3  = asushort(value); this = ashalf(temp); } }
        public half3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_4  = asushort(value); this = ashalf(temp); } }
        public half3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_5  = asushort(value); this = ashalf(temp); } }
        public half3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_6  = asushort(value); this = ashalf(temp); } }
        public half3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_7  = asushort(value); this = ashalf(temp); } }
        public half3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_8  = asushort(value); this = ashalf(temp); } }
        public half3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_9  = asushort(value); this = ashalf(temp); } }
        public half3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_10 = asushort(value); this = ashalf(temp); } }
        public half3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_11 = asushort(value); this = ashalf(temp); } }
        public half3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_12 = asushort(value); this = ashalf(temp); } }
        public half3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v3_13 = asushort(value); this = ashalf(temp); } }

        public half2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_0  = asushort(value); this = ashalf(temp); } }
        public half2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_1  = asushort(value); this = ashalf(temp); } }
        public half2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_2  = asushort(value); this = ashalf(temp); } }
        public half2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_3  = asushort(value); this = ashalf(temp); } }
        public half2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_4  = asushort(value); this = ashalf(temp); } }
        public half2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_5  = asushort(value); this = ashalf(temp); } }
        public half2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_6  = asushort(value); this = ashalf(temp); } }
        public half2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_7  = asushort(value); this = ashalf(temp); } }
        public half2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_8  = asushort(value); this = ashalf(temp); } }
        public half2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_9  = asushort(value); this = ashalf(temp); } }
        public half2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_10 = asushort(value); this = ashalf(temp); } }
        public half2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_11 = asushort(value); this = ashalf(temp); } }
        public half2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_12 = asushort(value); this = ashalf(temp); } }
        public half2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_13 = asushort(value); this = ashalf(temp); } }
        public half2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => ashalf(asushort(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { ushort16 temp = asushort(this); temp.v2_14 = asushort(value); this = ashalf(temp); } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(half16 input) => RegisterConversion.ToRegister256(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half16(v256 input) => RegisterConversion.ToAbstraction256<half16>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half16(half input) => new half16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half16(float input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half16(double input) => (half)input;


        public half this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return ashalf(asushort(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort16 cpy = asushort(this);
                cpy[index] = asushort(value);
                this = ashalf(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (half16 left, half16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Avx2.mm256_cmpeq_epi16(left, right));
            }
            else
            {
                return new bool16(left.v8_0 == right.v8_0, left.v8_8 == right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (half16 left, half16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse16(Avx2.mm256_cmpeq_epi16(left, right));
            }
            else
            {
                return new bool16(left.v8_0 != right.v8_0, left.v8_8 != right.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half16 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ushort>(Avx2.mm256_cmpeq_epi16(this, other));
            }
            else
            {
                return this.v8_0.Equals(other.v8_0) & this.v8_8.Equals(other.v8_8);
            }
        }

        public override readonly bool Equals(object obj) => obj is half16 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256(this);
            }
            else
            {
                return this._v8_0.GetHashCode() ^ this._v8_8.GetHashCode();
            }
        }


        public override readonly string ToString() =>  $"half16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"half16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}