using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(quarter8.DebuggerProxy))]
    unsafe public struct quarter8 : IEquatable<quarter8>, IFormattable
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

            public DebuggerProxy(quarter8 v)
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


        [FieldOffset(0)] public quarter x0;
        [FieldOffset(1)] public quarter x1;
        [FieldOffset(2)] public quarter x2;
        [FieldOffset(3)] public quarter x3;
        [FieldOffset(4)] public quarter x4;
        [FieldOffset(5)] public quarter x5;
        [FieldOffset(6)] public quarter x6;
        [FieldOffset(7)] public quarter x7;


        public static quarter8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0, quarter x1, quarter x2, quarter x3, quarter x4, quarter x5, quarter x6, quarter x7)
        {
            this = asquarter(new byte8(x0.value, x1.value, x2.value, x3.value, x4.value, x5.value, x6.value, x7.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter x0x8)
        {
            this = asquarter(new byte8(x0x8.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter2 x45, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x23), asbyte(x45), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter3 x234, quarter3 x567)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x234), asbyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter2 x34, quarter3 x567)
        {
            this = asquarter(new byte8(asbyte(x012), asbyte(x34), asbyte(x567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter3 x012, quarter3 x345, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x012), asbyte(x345), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter2 x45, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x0123), asbyte(x45), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter4 x2345, quarter2 x67)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x2345), asbyte(x67)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter2 x01, quarter2 x23, quarter4 x4567)
        {
            this = asquarter(new byte8(asbyte(x01), asbyte(x23), asbyte(x4567)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter8(quarter4 x0123, quarter4 x4567)
        {
            this = asquarter(new byte8(asbyte(x0123), asbyte(x4567)));
        }


        public quarter4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_0 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_1 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_2 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_3 = asbyte(value); this = asquarter(temp); } }
        public quarter4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v4_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v4_4 = asbyte(value); this = asquarter(temp); } }

        public quarter3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_0 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_1 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_2 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_3 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_4 = asbyte(value); this = asquarter(temp); } }
        public quarter3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v3_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v3_5 = asbyte(value); this = asquarter(temp); } }

        public quarter2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_0); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_0 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_1); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_1 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_2); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_2 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_3); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_3 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_4); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_4 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_5); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_5 = asbyte(value); this = asquarter(temp); } }
        public quarter2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).v2_6); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte8 temp = asbyte(this); temp.v2_6 = asbyte(value); this = asquarter(temp); } }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter8 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(v128 input) => RegisterConversion.ToAbstraction128<quarter8>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter8(quarter input) => new quarter8(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(byte8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, quarter.PositiveInfinity, elements: 8);
            }
            else
            {
                return new quarter8((quarter)input.x0,
                                    (quarter)input.x1,
                                    (quarter)input.x2,
                                    (quarter)input.x3,
                                    (quarter)input.x4,
                                    (quarter)input.x5,
                                    (quarter)input.x6,
                                    (quarter)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(sbyte8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, quarter.PositiveInfinity, elements: 8);
            }
            else
            {
                return new quarter8((quarter)input.x0,
                                    (quarter)input.x1,
                                    (quarter)input.x2,
                                    (quarter)input.x3,
                                    (quarter)input.x4,
                                    (quarter)input.x5,
                                    (quarter)input.x6,
                                    (quarter)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(ushort8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(input, quarter.PositiveInfinity, elements: 8);
            }
            else
            {
                return new quarter8((quarter)input.x0,
                                    (quarter)input.x1,
                                    (quarter)input.x2,
                                    (quarter)input.x3,
                                    (quarter)input.x4,
                                    (quarter)input.x5,
                                    (quarter)input.x6,
                                    (quarter)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(short8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(input, quarter.PositiveInfinity, elements: 8);
            }
            else
            {
                return new quarter8((quarter)input.x0,
                                    (quarter)input.x1,
                                    (quarter)input.x2,
                                    (quarter)input.x3,
                                    (quarter)input.x4,
                                    (quarter)input.x5,
                                    (quarter)input.x6,
                                    (quarter)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0,
                                    (quarter4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(int8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0,
                                    (quarter4)input.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(half8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(input, elements: 8);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter8(float8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtps_pq(input);
            }
            else
            {
                return new quarter8((quarter4)input.v4_0, (quarter4)input.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte8(quarter8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input, 8);
            }
            else
            {
                return new sbyte8((sbyte)input.x0, (sbyte)input.x1, (sbyte)input.x2, (sbyte)input.x3, (sbyte)input.x4, (sbyte)input.x5, (sbyte)input.x6, (sbyte)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(quarter8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input, 8);
            }
            else
            {
                return new byte8((byte)input.x0, (byte)input.x1, (byte)input.x2, (byte)input.x3, (byte)input.x4, (byte)input.x5, (byte)input.x6, (byte)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(quarter8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(input, 8);
            }
            else
            {
                return new short8((short)input.x0, (short)input.x1, (short)input.x2, (short)input.x3, (short)input.x4, (short)input.x5, (short)input.x6, (short)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(quarter8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(input, 8);
            }
            else
            {
                return new ushort8((ushort)input.x0, (ushort)input.x1, (ushort)input.x2, (ushort)input.x3, (ushort)input.x4, (ushort)input.x5, (ushort)input.x6, (ushort)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(quarter8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi32(input);
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                int4 lo = RegisterConversion.ToInt4(Xse.cvttpq_epi32(input));
                int4 hi = RegisterConversion.ToInt4(Xse.cvttpq_epi32(Xse.bsrli_si128(input, 4 * sizeof(quarter))));

                return new int8(lo, hi);
            }
            else
            {
                return new int8((int)input.x0, (int)input.x1, (int)input.x2, (int)input.x3, (int)input.x4, (int)input.x5, (int)input.x6, (int)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(quarter8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu32(input);
            }
            if (BurstArchitecture.IsSIMDSupported)
            {
                uint4 lo = RegisterConversion.ToUInt4(Xse.cvttpq_epu32(input));
                uint4 hi = RegisterConversion.ToUInt4(Xse.cvttpq_epu32(Xse.bsrli_si128(input, 4 * sizeof(quarter))));

                return new uint8(lo, hi);
            }
            else
            {
                return new uint8((uint)input.x0, (uint)input.x1, (uint)input.x2, (uint)input.x3, (uint)input.x4, (uint)input.x5, (uint)input.x6, (uint)input.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(quarter8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ph(input, elements: 8);
            }
            else
            {
                return new half8(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(quarter8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_ps(input);
            }
            else
            {
                return new float8((float4)input.v4_0, (float4)input.v4_4);
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
                byte8 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 operator - (quarter8 value)
        {
            return asquarter(asbyte(value) ^ new byte8(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpeq_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, quarter right)
        {
            return left == (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter left, quarter8 right)
        {
            return (quarter8)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (half left, quarter8 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, half8 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right, 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (half8 left, quarter8 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (float left, quarter8 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, float8 right)
        {
            if (constexpr.IS_TRUE(all(right == 0f)))
            {
                return left == default(quarter8);
            }
            else
            {
                return (float8)left == (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (float8 left, quarter8 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (quarter8 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 == right, (double4)left.v4_4 == right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (double left, quarter8 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpneq_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, quarter right)
        {
            return left != (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter left, quarter8 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (half left, quarter8 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, half8 right)
        {
            if (constexpr.ALL_EQ_PS((float8)right, 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (half8 left, quarter8 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (float left, quarter8 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, float8 right)
        {
            if (constexpr.IS_TRUE(all(right == 0f)))
            {
                return left != default(quarter8);
            }
            else
            {
                return (float8)left != (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (float8 left, quarter8 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (quarter8 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 != right, (double4)left.v4_4 != right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (double left, quarter8 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, quarter8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, quarter right)
        {
            return left < (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter left, quarter8 right)
        {
            return (quarter8)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (half left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, half8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all((float8)right == 0f)))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (half8 left, quarter8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all((float8)left == 0f)))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (float left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, float8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all(right == 0f)))
            {
                return left < default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (float8 left, quarter8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all(left == 0f)))
            {
                return right > default(quarter8);
            }
            else
            {
                return (float8)left < (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (quarter8 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 < (double4)right, (double4)left.v4_4 < (double4)right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (double left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter8);
            }
            else
            {
                return new bool8((double4)left < (double4)right.v4_0, (double4)left < (double4)right.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (half left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, half8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (half8 left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (float left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, float8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (float8 left, quarter8 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (quarter8 left, double right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (double left, quarter8 right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, quarter8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmple_pq(left, right, elements: 8));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, quarter right)
        {
            return left <= (quarter8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter left, quarter8 right)
        {
            return (quarter8)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (half left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, half8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all((float8)right == 0f)))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (half8 left, quarter8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all((float8)left == 0f)))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (float left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, float8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all(right == 0f)))
            {
                return left <= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (float8 left, quarter8 right)
        {
            if (constexpr.IS_TRUE(maxmath.all(left == 0f)))
            {
                return right >= default(quarter8);
            }
            else
            {
                return (float8)left <= (float8)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (quarter8 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter8);
            }
            else
            {
                return new bool8((double4)left.v4_0 <= (double4)right, (double4)left.v4_4 <= (double4)right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (double left, quarter8 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter8);
            }
            else
            {
                return new bool8((double4)left <= (double4)right.v4_0, (double4)left <= (double4)right.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (half left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, half8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (half8 left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (float left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, float8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (float8 left, quarter8 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (quarter8 left, double right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (double left, quarter8 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter8 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vcmpeq_pq(this, other, elements: 8);
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override bool Equals(object obj) => obj is quarter8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Hash.v64(this);
            }
            else
            {
                quarter8 temp = this;
                return (*(long*)&temp).GetHashCode();
            }
        }


        public override string ToString() => $"quarter8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}