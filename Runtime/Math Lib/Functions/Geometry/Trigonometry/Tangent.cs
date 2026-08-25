using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the tangent of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tan(float x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tan(float2 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tan(float3 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tan(float4 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = tan(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(tan(x.v4_0), tan(x.v4_4));
            }
        }

        
        /// <summary>       Returns the tangent of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double tan(double x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tan(double2 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tan(double3 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tan(double4 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static quadruple.ConstChecked tan_kernel(quadruple.ConstChecked x, quadruple.ConstChecked y, int iy)
        {
            quadruple.ConstChecked pio4hi = new quadruple(0x8469_898C_C517_01B8, 0x3FFE_921F_B544_42D1);
            quadruple.ConstChecked pio4lo = new quadruple(0xA67C_C740_20BB_EA64, 0x3F8B_CD12_9024_E088);
            quadruple.ConstChecked TH     = new quadruple(0x5555_5555_5555_5555, 0x3FFD_5555_5555_5555);
            quadruple.ConstChecked T0     = new quadruple(0x5C07_8DC5_B638_EBB1, 0xC017_14A4_E31E_1046);
            quadruple.ConstChecked T1     = new quadruple(0x391E_B3B3_6183_DBA9, 0x4013_4273_FF5C_325E);
            quadruple.ConstChecked T2     = new quadruple(0x5D55_D33B_EF12_EC7D, 0xC00D_9A6F_04E5_B80F);
            quadruple.ConstChecked T3     = new quadruple(0x32D7_127D_7728_4935, 0x4006_60EA_27E5_EE37);
            quadruple.ConstChecked T4     = new quadruple(0x42AF_7F6C_9AFB_5414, 0xBFFD_5553_9D4D_C55B);
            quadruple.ConstChecked U0     = new quadruple(0xF647_14E9_5AD5_6D1A, 0xC01A_035A_94EC_2F41);
            quadruple.ConstChecked U1     = new quadruple(0x97EE_A94E_B65D_F7F4, 0x4018_EF7B_2D27_3DA6);
            quadruple.ConstChecked U2     = new quadruple(0x4D1A_DCA0_129F_6133, 0xC014_FE59_9D60_BE47);
            quadruple.ConstChecked U3     = new quadruple(0x101A_5B27_166A_9F60, 0x400F_39BC_7009_E665);
            quadruple.ConstChecked U4     = new quadruple(0xC560_DC18_C7D3_A0E5, 0xC008_0A28_148D_42F2);

            quadruple.ConstChecked z, r, v, w, s;

            int ix = (int)(x.Value.value.hi64 >> 32) & 0x7FFF_FFFF;
            if (ix < 0x3FC6_0000)
            {
                if ((int)x.Value == 0)
	            {
	                if ((asuint128(abs(x)) | (uint)(iy + 1)) == 0)
                    {
                        return rcp(abs(x));
                    }
	                else if (iy == 1)
	                {
	                    return x;
	                }
	                else
                    {
                        return -rcp(x);
                    }
	            }
            }

            ulong signx = 0;
            if (ix >= 0x3FFE_5942)
            {
                signx = x.Value.value.hi64 & (1ul << 63);
                x.Value = new quadruple(x.Value.value.lo64, x.Value.value.hi64 ^ signx);
                y.Value = new quadruple(y.Value.value.lo64, y.Value.value.hi64 ^ signx);
                if (signx != 0)
	            {
                    x.Promise.FlipSign();
                    y.Promise.FlipSign();
	            }

                z = pio4hi - x;
                w = pio4lo - y;
                x = z + w;
                y = 0;
            }
            z = square(x);
            v = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(x, x, U4), z, U3), z, U2), z, U1), z, U0);
            r = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(T4, z, T3), z, T2), z, T1), z, T0);
            r /= v;

            s = z * x;
            r = quadruple.fmadd(quadruple.fmadd(s, r, y), z, y);
            r = quadruple.fmadd(TH, s, r);
            w = x + r;

            if (ix >= 0x3FFE_5942)
            {
                v = (quadruple)iy;
                w = quadruple.fmadd(-2, x - (square(w) / (w + v) - r), v);
                
                w.Value = new quadruple(w.Value.value.lo64, w.Value.value.hi64 ^ signx);
                return w;
            }
            else if (iy == 1)
            {
                return w;
            }
            else
            {
                if (COMPILATION_OPTIONS.FLOAT_PRECISION != FloatPrecision.High)
                {
                    return -rcp(x + r);
                }
                else
                {
                    quadruple.ConstChecked w2 = new quadruple(0, w.Value.value.hi64);
                    v = r - (w2 - x);
                    z = -rcp(w);
                    quadruple.ConstChecked z2 = new quadruple(0, z.Value.value.hi64);
                    s = quadruple.fmadd(z2, w2, 1);
                    return quadruple.fmadd(quadruple.fmadd(z2, v, s), z, z2);
                }
            }
        }
        
        /// <summary>       Returns the tangent of a <see cref="quadruple"/>.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple tan(quadruple x)
        {
            long ix = (long)x.value.hi64;
        	ix &= 0x7FFF_FFFF_FFFF_FFF;

	        if (ix <= 0x3FFE_921F_B544_42D1)
            {
	            return tan_kernel(x, 0, 1);
            }
        	else if (ix >= 0x7FFF_0000_0000_0000)
            {
        	    return x;
        	}
        	else 
            {
        	    quadruple* y = stackalloc quadruple[2];
        	    int n = rem_pio2(x, y);

	            return tan_kernel(y[0], y[1], 1 - ((n & 1) << 1));
	        }
        }
    }
}