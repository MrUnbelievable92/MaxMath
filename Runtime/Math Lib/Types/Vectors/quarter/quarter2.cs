using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 2 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(quarter2.DebuggerProxy))]
    unsafe public struct quarter2 : IEquatable<quarter2>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x;
            public quarter y;

            public DebuggerProxy(quarter2 v)
            {
                x = v.x;
                y = v.y;
            }
        }


        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;


        public static quarter2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter x, quarter y)
        {
            this = asquarter(new byte2(x.value, y.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter xy)
        {
            this = asquarter(new byte2(xy.value));
        }


        #region Shuffle
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }

        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }

        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter2 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(v128 input) => RegisterConversion.ToAbstraction128<quarter2>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(quarter input) => new quarter2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(input, quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(input, quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(RegisterConversion.ToV128(input), quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(RegisterConversion.ToV128(input), quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_pq(input, quarter.PositiveInfinity);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(RegisterConversion.ToV128(input), elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_pq(RegisterConversion.ToV128(input), elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_pq(RegisterConversion.ToV128(input));
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input, 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(input, 2);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(input, 2);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cvttpq_epi32(input, 2));
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cvttpq_epu32(input, 2));
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.cvtpq_ph(input, elements: 2));
            }
            else
            {
                return new half2(input.x, input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.cvtpq_ps(input, elements: 2));
            }
            else
            {
                return new float2(input.x, input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.cvtpq_pd(input));
            }
            else
            {
                return new double2((double)input.x, (double)input.y);
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
                byte2 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 operator - (quarter2 value)
        {
            return asquarter(asbyte(value) ^ new byte2(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmpeq_pq(left, right, elements: 2));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, quarter right)
        {
            return left == (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, half2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half2 left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (float left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, float2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (float2)left == (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (float2 left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (double left, quarter2 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (quarter2 left, double2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter2);
            }
            else
            {
                return (double2)left == (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (double2 left, quarter2 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue8(Xse.cmpneq_pq(left, right, elements: 2));

                return *(bool2*)&results;
            }
            else
            {
                return new bool2(left.x != right.x, left.y != right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, quarter right)
        {
            return left != (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, half2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half2 left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (float left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, float2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (float2)left != (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (float2 left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (double left, quarter2 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (quarter2 left, double2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter2);
            }
            else
            {
                return (double2)left != (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (double2 left, quarter2 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmplt_pq(left, right, elements: 2)));
            }
            else
            {
                return new bool2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, quarter right)
        {
            return left < (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter left, quarter2 right)
        {
            return (quarter2)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, half2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (float left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, float2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (float2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return (float2)left < (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter2);
            }
            else
            {
                return (double2)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (double left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter2);
            }
            else
            {
                return left < (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (quarter2 left, double2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter2);
            }
            else
            {
                return (double2)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (double2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter2);
            }
            else
            {
                return left < (double2)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, half2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half2 left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (float left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, float2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (float2 left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, double right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (double left, quarter2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (quarter2 left, double2 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (double2 left, quarter2 right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmple_pq(left, right, elements: 2)));
            }
            else
            {
                return new bool2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, quarter right)
        {
            return left <= (quarter2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter left, quarter2 right)
        {
            return (quarter2)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, half right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, half2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all((float2)left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, float right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (float left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, float2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (float2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return (float2)left <= (float2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, double right)
        {
            if (constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (double2)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (double left, quarter2 right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter2);
            }
            else
            {
                return left <= (double2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (quarter2 left, double2 right)
        {
            if (constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter2);
            }
            else
            {
                return (double2)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (double2 left, quarter2 right)
        {
            if (constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter2);
            }
            else
            {
                return left <= (double2)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, half2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half2 left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (float left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, float2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (float2 left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, double right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (double left, quarter2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (quarter2 left, double2 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (double2 left, quarter2 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter2 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vcmpeq_pq(this, other, elements: 2);
            }
            else
            {
                return this.x == other.x && this.y == other.y;
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return ((v128)this).UShort0;
            }
            else
            {
                quarter2 temp = this;
                return *(ushort*)&temp;
            }
        }


        public override readonly string ToString() => $"quarter2({x}, {y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}