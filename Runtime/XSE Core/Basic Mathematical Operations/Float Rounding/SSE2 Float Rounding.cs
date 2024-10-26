using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_ss(v128 a, v128 b, int rounding)
		{
            if (Architecture.IsSIMDSupported)
            {
                return move_ss(a, round_ps(b, rounding));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 floor_ss(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.floor_ss(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_ss(a, floor_ps(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceil_ss(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.ceil_ss(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_ss(a, ceil_ps(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
                return move_ss(a, round_ps(b));
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_ss(a, round_ps(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 trunc_ss(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
                return move_ss(a, trunc_ps(b));
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_ss(a, trunc_ps(b));
            }
			else throw new IllegalInstructionException();
		}
        

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_sd(v128 a, v128 b, int rounding)
		{
            if (Architecture.IsSIMDSupported)
            {
                return move_sd(a, round_pd(b, rounding));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 floor_sd(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.floor_sd(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_sd(a, floor_pd(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceil_sd(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.ceil_sd(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_sd(a, ceil_pd(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
                return move_sd(a, round_pd(b));
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_sd(a, round_pd(b));
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 trunc_sd(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
                return move_sd(a, trunc_pd(b));
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return move_sd(a, trunc_pd(b));
            }
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_ps(v128 a, int rounding, byte elements = 4)
		{
            if (Architecture.IsSIMDSupported)
            {
                switch (rounding)
                {
                    case (FROUND_TO_NEAREST_INT | FROUND_NO_EXC): return round_ps(a, elements);
                    case (FROUND_TO_NEG_INF | FROUND_NO_EXC): return floor_ps(a, elements);
                    case (FROUND_TO_POS_INF | FROUND_NO_EXC): return ceil_ps(a, elements);
                    case (FROUND_TO_ZERO | FROUND_NO_EXC): return trunc_ps(a, elements);
                    default: return round_ps(a, elements);
                }
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 floor_ps(v128 a, byte elements = 4)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.floor_ps(a);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat(a)));
                    case 2:  return RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat2(a)));
                    case 3:  return RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat3(a)));
                    default: return RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat4(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndmq_f32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 ceil_ps(v128 a, byte elements = 4)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.ceil_ps(a);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToFloat(a)));
                    case 2:  return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToFloat2(a)));
                    case 3:  return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToFloat3(a)));
                    default: return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToFloat4(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndpq_f32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 round_ps(v128 a, byte elements = 4)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.round_ps(a, (int)RoundingMode.FROUND_NINT);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.round(RegisterConversion.ToFloat(a)));
                    case 2:  return RegisterConversion.ToV128(math.round(RegisterConversion.ToFloat2(a)));
                    case 3:  return RegisterConversion.ToV128(math.round(RegisterConversion.ToFloat3(a)));
                    default: return RegisterConversion.ToV128(math.round(RegisterConversion.ToFloat4(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndnq_f32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 trunc_ps(v128 a, byte elements = 4)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.round_ps(a, (int)RoundingMode.FROUND_TRUNC);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToFloat(a)));
                    case 2:  return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToFloat2(a)));
                    case 3:  return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToFloat3(a)));
                    default: return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToFloat4(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndq_f32(a);
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 round_pd(v128 a, int rounding, byte elements = 2)
		{
            if (Architecture.IsSIMDSupported)
            {
                switch (rounding)
                {
                    case (FROUND_TO_NEAREST_INT | FROUND_NO_EXC): return round_pd(a, elements);
                    case (FROUND_TO_NEG_INF | FROUND_NO_EXC): return floor_pd(a, elements);
                    case (FROUND_TO_POS_INF | FROUND_NO_EXC): return ceil_pd(a, elements);
                    case (FROUND_TO_ZERO | FROUND_NO_EXC): return trunc_pd(a, elements);
                    default: return round_pd(a, elements);
                }
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 floor_pd(v128 a, byte elements = 2)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.floor_pd(a);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.floor(RegisterConversion.ToDouble(a)));
                    default: return RegisterConversion.ToV128(math.floor(RegisterConversion.ToDouble2(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndmq_f64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 ceil_pd(v128 a, byte elements = 2)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.ceil_pd(a);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToDouble(a)));
                    default: return RegisterConversion.ToV128(math.ceil(RegisterConversion.ToDouble2(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndpq_f64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 round_pd(v128 a, byte elements = 2)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.round_pd(a, (int)RoundingMode.FROUND_NINT);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.round(RegisterConversion.ToDouble(a)));
                    default: return RegisterConversion.ToV128(math.round(RegisterConversion.ToDouble2(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndnq_f64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 trunc_pd(v128 a, byte elements = 2)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.round_pd(a, (int)RoundingMode.FROUND_TRUNC);
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (elements)
                {
                    case 1:  return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToDouble(a)));
                    default: return RegisterConversion.ToV128(math.trunc(RegisterConversion.ToDouble2(a)));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrndq_f64(a);
            }
            else throw new IllegalInstructionException();
        }
    }
}
