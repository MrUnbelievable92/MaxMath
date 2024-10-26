using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // In managed code, keep them fixed to 8-bit 1s or 0s (true booleans)
    // In Burst code, store raw generated SIMD masks (always 128/256bits)
    //
    // all shuffles, operators (exact boolX API)
    unsafe internal     readonly ref    struct mask8x3
    {
        private readonly byte16 _mask;


        internal mask8x3(v128 mask)
        {
            this._mask = mask;
        }


        public static implicit operator mask32x3(mask8x3 input)
        {
            return Xse.cvtepi8_epi32(input);
        }

        public static explicit operator mask8x3(mask32x3 input)
        {
            return Xse.cvtepi32_epi8(input, 3);
        }

        public static implicit operator bool3(mask8x3 input)
        {
            return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(input));
        }

        public static implicit operator mask8x3(bool3 input)
        {
            return Sse2.cmpeq_epi8(Xse.set1_epi8(1), RegisterConversion.ToV128(input));
        }

        public static implicit operator v128(mask8x3 input)
        {
            return input._mask;
        }

        public static implicit operator mask8x3(v128 input)
        {
            return new mask8x3(input);
        }
    }

    unsafe internal     readonly ref    struct mask32x3
    {
        private readonly int4 _mask;

        internal mask32x3(v128 mask)
        {
            this._mask = RegisterConversion.ToInt4(mask);
        }


        public static implicit operator bool3(mask32x3 input)
        {
            return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(input));
        }

        public static implicit operator mask32x3(bool3 input)
        {
            return (mask8x3)input;
        }

        public static implicit operator v128(mask32x3 input)
        {
            return RegisterConversion.ToV128(input._mask);
        }

        public static implicit operator mask32x3(v128 input)
        {
            return new mask32x3(input);
        }
    }
}
