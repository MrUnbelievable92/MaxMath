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
    [StructLayout(LayoutKind.Sequential, Size = 16 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(quarter16.DebuggerProxy))]
    unsafe public struct quarter16 : IEquatable<quarter16>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x0;
            public quarter x1;
            public quarter x2;
            public quarter x3;
            public quarter x4;
            public quarter x5;
            public quarter x6;
            public quarter x7;
            public quarter x8;
            public quarter x9;
            public quarter x10;
            public quarter x11;
            public quarter x12;
            public quarter x13;
            public quarter x14;
            public quarter x15;

            public DebuggerProxy(quarter16 v)
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


        public quarter x0;
        public quarter x1;
        public quarter x2;
        public quarter x3;
        public quarter x4;
        public quarter x5;
        public quarter x6;
        public quarter x7;
        public quarter x8;
        public quarter x9;
        public quarter x10;
        public quarter x11;
        public quarter x12;
        public quarter x13;
        public quarter x14;
        public quarter x15;


        public static quarter16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7, quarter x8, quarter x9, quarter x10, quarter x11, quarter x12, quarter x13, quarter x14, quarter x15)
        {
            this = asquarter(new byte16(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value, x8.value, x9.value, x10.value, x11.value, x12.value, x13.value, x14.value, x15.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter x0x16)
        {
            this = asquarter(new byte16(x0x16.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67, quarter2 x89, quarter2 x10_11, quarter2 x12_13, quarter2 x14_15)
        {
            this = asquarter(new byte16(asbyte(x01), asbyte(x23), asbyte(x45), asbyte(x67), asbyte(x89), asbyte(x10_11), asbyte(x12_13), asbyte(x14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter4 x0123, quarter4 x4567, quarter4 x8_9_10_11, quarter4 x12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x0123), asbyte(x4567), asbyte(x8_9_10_11), asbyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter4 x0123, quarter3 x456, quarter3 x789, quarter3 x10_11_12, quarter3 x13_14_15)
        {
            this = asquarter(new byte16(asbyte(x0123), asbyte(x456), asbyte(x789), asbyte(x10_11_12), asbyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter3 x012, quarter4 x3456, quarter3 x789, quarter3 x10_11_12, quarter3 x13_14_15)
        {
            this = asquarter(new byte16(asbyte(x012), asbyte(x3456), asbyte(x789), asbyte(x10_11_12), asbyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter3 x012, quarter3 x345, quarter4 x6789, quarter3 x10_11_12, quarter3 x13_14_15)
        {
            this = asquarter(new byte16(asbyte(x012), asbyte(x345), asbyte(x6789), asbyte(x10_11_12), asbyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter3 x012, quarter3 x345, quarter3 x678, quarter4 x9_10_11_12, quarter3 x13_14_15)
        {
            this = asquarter(new byte16(asbyte(x012), asbyte(x345), asbyte(x678), asbyte(x9_10_11_12), asbyte(x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter3 x012, quarter3 x345, quarter3 x678, quarter3 x9_10_11, quarter4 x12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x012), asbyte(x345), asbyte(x678), asbyte(x9_10_11), asbyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter8 x01234567, quarter4 x8_9_10_11, quarter4 x12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x01234567), asbyte(x8_9_10_11), asbyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter4 x0123, quarter8 x4_5_6_7_8_9_10_11, quarter4 x12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x0123), asbyte(x4_5_6_7_8_9_10_11), asbyte(x12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter4 x0123, quarter4 x4567, quarter8 x8_9_10_11_12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x0123), asbyte(x4567), asbyte(x8_9_10_11_12_13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter16(quarter8 x01234567, quarter8 x8_9_10_11_12_13_14_15)
        {
            this = asquarter(new byte16(asbyte(x01234567), asbyte(x8_9_10_11_12_13_14_15)));
        }


        #region Shuffle
        public quarter8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_0 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_1 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_2 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_3 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_4 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_5 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_6 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_7); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_7 = asbyte(value); this = asquarter(temp); } }
        public quarter8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v8_8); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v8_8 = asbyte(value); this = asquarter(temp); } }

        public quarter4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_0  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_1  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_2  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_3  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_4  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_5  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_6  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_7  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_8  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_9  = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_10 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_11 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v4_12 = asbyte(value); this = asquarter(temp); } }

        public quarter3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_0  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_1  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_2  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_3  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_4  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_5  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_6  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_7  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_8  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_9  = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_10 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_11 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_12 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v3_13 = asbyte(value); this = asquarter(temp); } }

        public quarter2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_0);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_0  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_1);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_1  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_2);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_2  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_3);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_3  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_4);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_4  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_5);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_5  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_6);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_6  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_7);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_7  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_8);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_8  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_9);  [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_9  = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_10); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_10 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_11); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_11 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_12); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_12 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_13); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_13 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_14); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte16 temp = asbyte(this); temp.v2_14 = asbyte(value); this = asquarter(temp); } }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter16 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter16(v128 input) => RegisterConversion.ToAbstraction128<quarter16>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter16(quarter input) => new quarter16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(byte16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter16((quarter)input.x0,
                                     (quarter)input.x1,
                                     (quarter)input.x2,
                                     (quarter)input.x3,
                                     (quarter)input.x4,
                                     (quarter)input.x5,
                                     (quarter)input.x6,
                                     (quarter)input.x7,
                                     (quarter)input.x8,
                                     (quarter)input.x9,
                                     (quarter)input.x10,
                                     (quarter)input.x11,
                                     (quarter)input.x12,
                                     (quarter)input.x13,
                                     (quarter)input.x14,
                                     (quarter)input.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(sbyte16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter16((quarter)input.x0,
                                     (quarter)input.x1,
                                     (quarter)input.x2,
                                     (quarter)input.x3,
                                     (quarter)input.x4,
                                     (quarter)input.x5,
                                     (quarter)input.x6,
                                     (quarter)input.x7,
                                     (quarter)input.x8,
                                     (quarter)input.x9,
                                     (quarter)input.x10,
                                     (quarter)input.x11,
                                     (quarter)input.x12,
                                     (quarter)input.x13,
                                     (quarter)input.x14,
                                     (quarter)input.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(ushort16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu16_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter16((quarter8)input.v8_0,
                                     (quarter8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(short16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi16_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter16((quarter8)input.v8_0,
                                     (quarter8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter16(half16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtph_pq(input);
            }
            else
            {
                return new quarter16((quarter8)input.v8_0, (quarter8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(quarter16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input);
            }
            else
            {
                return new sbyte16((sbyte)input.x0, (sbyte)input.x1, (sbyte)input.x2, (sbyte)input.x3, (sbyte)input.x4, (sbyte)input.x5, (sbyte)input.x6, (sbyte)input.x7, (sbyte)input.x8, (sbyte)input.x9, (sbyte)input.x10, (sbyte)input.x11, (sbyte)input.x12, (sbyte)input.x13, (sbyte)input.x14, (sbyte)input.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(quarter16 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input);
            }
            else
            {
                return new byte16((byte)input.x0, (byte)input.x1, (byte)input.x2, (byte)input.x3, (byte)input.x4, (byte)input.x5, (byte)input.x6, (byte)input.x7, (byte)input.x8, (byte)input.x9, (byte)input.x10, (byte)input.x11, (byte)input.x12, (byte)input.x13, (byte)input.x14, (byte)input.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short16(quarter16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi16(input);
            }
            else
            {
                return new short16((short8)input.v8_0, (short8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort16(quarter16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu16(input);
            }
            else
            {
                return new ushort16((ushort8)input.v8_0, (ushort8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half16(quarter16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_ph(input);
            }
            else
            {
                return new half16((half8)input.v8_0, (half8)input.v8_8);
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return asquarter(asbyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte16 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 operator - (quarter16 value)
        {
            return asquarter(asbyte(value) ^ new byte16(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, quarter16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpeq_pq(left, right));
            }
            else
            {
                return new bool16(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7, left.x8 == right.x8, left.x9 == right.x9, left.x10 == right.x10, left.x11 == right.x11, left.x12 == right.x12, left.x13 == right.x13, left.x14 == right.x14, left.x15 == right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, quarter right)
        {
            return left == (quarter16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter left, quarter16 right)
        {
            return (quarter16)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 == right, left.v8_8 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (half left, quarter16 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, half16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return left == default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 == right.v8_0, left.v8_8 == right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (half16 left, quarter16 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 == right, left.v8_8 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (float left, quarter16 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (quarter16 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter16);
            }
            else
            {
                return new bool16(left.v4_0 == right, left.v4_4 == right, left.v4_8 == right, left.v4_12 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (double left, quarter16 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, quarter16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpneq_pq(left, right));
            }
            else
            {
                return new bool16(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7, left.x8 != right.x8, left.x9 != right.x9, left.x10 != right.x10, left.x11 != right.x11, left.x12 != right.x12, left.x13 != right.x13, left.x14 != right.x14, left.x15 != right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, quarter right)
        {
            return left != (quarter16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter left, quarter16 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 != right, left.v8_8 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (half left, quarter16 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, half16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return left != default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 != right.v8_0, left.v8_8 != right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (half16 left, quarter16 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 != right, left.v8_8 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (float left, quarter16 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (quarter16 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter16);
            }
            else
            {
                return new bool16(left.v4_0 != right, left.v4_4 != right, left.v4_8 != right, left.v4_12 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (double left, quarter16 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, quarter16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_pq(left, right));
            }
            else
            {
                return new bool16(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7, left.x8 < right.x8, left.x9 < right.x9, left.x10 < right.x10, left.x11 < right.x11, left.x12 < right.x12, left.x13 < right.x13, left.x14 < right.x14, left.x15 < right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, quarter right)
        {
            return left < (quarter16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter left, quarter16 right)
        {
            return (quarter16)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 < right, left.v8_8 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (half left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left < right.v8_0, left < right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, half16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return left < default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 < right.v8_0, left.v8_8 < right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (half16 left, quarter16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 < right.v8_0, left.v8_8 < right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 < right, left.v8_8 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (float left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left < right.v8_0, left < right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (quarter16 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter16);
            }
            else
            {
                return new bool16(left.v4_0 < right, left.v4_4 < right, left.v4_8 < right, left.v4_12 < right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (double left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left < right.v4_0, left < right.v4_4, left < right.v4_8, left < right.v4_12);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, quarter16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter left, quarter16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (half left, quarter16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, half16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (half16 left, quarter16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (float left, quarter16 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (quarter16 left, double right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (double left, quarter16 right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, quarter16 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmple_pq(left, right));
            }
            else
            {
                return new bool16(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7, left.x8 <= right.x8, left.x9 <= right.x9, left.x10 <= right.x10, left.x11 <= right.x11, left.x12 <= right.x12, left.x13 <= right.x13, left.x14 <= right.x14, left.x15 <= right.x15);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, quarter right)
        {
            return left <= (quarter16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter left, quarter16 right)
        {
            return (quarter16)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 <= right, left.v8_8 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (half left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left <= right.v8_0, left <= right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, half16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return left <= default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 <= right.v8_0, left.v8_8 <= right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (half16 left, quarter16 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right.v8_0, 0f)
             && constexpr.ALL_EQ_PS((float8)right.v8_8, 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 <= right.v8_0, left.v8_8 <= right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter16);
            }
            else
            {
                return new bool16(left.v8_0 <= right, left.v8_8 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (float left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left <= right.v8_0, left <= right.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (quarter16 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter16);
            }
            else
            {
                return new bool16(left.v4_0 <= right, left.v4_4 <= right, left.v4_8 <= right, left.v4_12 <= right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (double left, quarter16 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter16);
            }
            else
            {
                return new bool16(left <= right.v4_0, left <= right.v4_4, left <= right.v4_8, left <= right.v4_12);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, quarter16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter left, quarter16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (half left, quarter16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, half16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (half16 left, quarter16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (float left, quarter16 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (quarter16 left, double right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (double left, quarter16 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter16 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<byte>(Xse.cmpeq_pq(this, other));
            }
            else
            {
                return this.v8_0.Equals(other.v8_0) & this.v8_8.Equals(other.v8_8);
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter16 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Hash.v128(this);
            }
            else
            {
                quarter16 temp = this;
                return (((ulong*)&temp)[0] ^ ((ulong*)&temp)[1]).GetHashCode();
            }
        }


        public override readonly string ToString() =>  $"quarter16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}