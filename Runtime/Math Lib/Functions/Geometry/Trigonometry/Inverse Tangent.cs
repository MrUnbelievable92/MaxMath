using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the arctangent of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float atan(float x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 atan(float2 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 atan(float3 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 atan(float4 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = atan(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(atan(x.v4_0), atan(x.v4_4));
            }
        }

        
        /// <summary>       Returns the arctangent of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double atan(double x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 atan(double2 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 atan(double3 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 atan(double4 x)
        {
            return Unity.Mathematics.math.atan(x);
        }

        
        /// <summary>       Returns the arctangent of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple atan(quadruple x)
        {
            quadruple p0 = new quadruple(0xA2F4_90C7_A11F_5B33, 0xC004_56B2_58DE_0624);
            quadruple p1 = new quadruple(0x8BD7_E11D_01FA_01E3, 0xC005_5971_FF2D_C71F);
            quadruple p2 = new quadruple(0xDD6D_814E_207A_0EBD, 0xC004_C915_9A71_5901);
            quadruple p3 = new quadruple(0x6D31_9905_4918_7861, 0xC002_B6D9_8E50_9393);
            quadruple p4 = new quadruple(0x0F52_4BC1_81B8_EB29, 0xBFFE_BA46_CD76_B385);
            quadruple q0 = new quadruple(0x7A37_6C95_B8D7_88F9, 0x4006_0105_C2A6_849B);
            quadruple q1 = new quadruple(0x80BF_5635_DF24_276C, 0x4007_5030_D361_16B9);
            quadruple q2 = new quadruple(0xCC7E_9E53_1B76_2A1E, 0x4007_3E0B_7A01_1382);
            quadruple q3 = new quadruple(0xD098_0D5A_3341_4452, 0x4006_0572_E65A_2C1C);
            quadruple q4 = new quadruple(0x8EEF_12B2_4E50_81A4, 0x4003_5BC7_A0E3_0D94);

            quadruple.ConstChecked t, u, p, q;

            ulong sign = x.value.hi64 & (1ul << 63);
            int k = (int)(x.value.hi64 >> 32);

            k &= 0x7FFF_FFFF;
            if (k >= 0x7FFF_0000)
            {
                if (isnan(x))
                {
                    return x;
                }

                quadruple.ConstChecked r = LUT.QUADRUPLE.atan(83);
                r.Value = new quadruple(r.Value.value.lo64, r.Value.value.hi64 ^ sign);
            }
            else if (k <= 0x3FC5_0000)
            {
	            return x;
            }
            else if (k >= 0x4072_0000)
            {
                quadruple.ConstChecked r = LUT.QUADRUPLE.atan(83);
                r.Value = new quadruple(r.Value.value.lo64, r.Value.value.hi64 ^ sign);
            }

            x = abs(x);

            if (k >= 0x4002_4800)
            {
                k = 83;
                t = -rcp(x);
            }
            else
            {
                k = (int)quadruple.fmadd(8, x, 0.25).Value;
                u = 0.125 * k;
                t = (x - u) / quadruple.fmadd(x, u, 1);
            }

            u = square(t);
            p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(p4, u, p3), u, p2), u, p1), u, p0);
            q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(u + q4, u, q3), u, q2), u, q1), u, q0);
            u = quadruple.fmadd(t * u, p / q, t);

            u = LUT.QUADRUPLE.atan(k) + u;
            return new quadruple(u.Value.value.lo64, u.Value.value.hi64 ^ sign);
        }
    }
}