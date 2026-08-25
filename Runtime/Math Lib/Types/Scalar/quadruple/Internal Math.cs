#define EVEN_ON_TIE

using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;
using DevTools;

using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public static partial class math
    {
        internal static UInt128 ONE_AS_QUADRUPLE => new UInt128(0ul, 0x3FFF_0000_0000_0000ul);
        internal static int F128_ROUND_SHIFT_BASE => quadruple.MANTISSA_BITS + abs(quadruple.EXPONENT_BIAS);
        internal static quadruple ONE_THIRD_QUADRUPLE => new quadruple(0x5555_5555_5555_5555, 0x3FFD_5555_5555_5555);
        internal static quadruple FOUR_THIRDS_QUADRUPLE => new quadruple(0x5555_5555_5555_5555, 0x3FFF_5555_5555_5555);
        internal static quadruple tinyQuadruple => new quadruple(0x742A_E235_CC08_1BD0, 0x1911_2949_9E40_33AF);
        internal static quadruple hugeQuadruple => new quadruple(0x5EA6_6F64_97E3_640B, 0x66EC_B8E4_99A8_8823);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double scalbn (double x, int n)
        {
            int lx = (int)asulong(x);
            int hx = (int)(asulong(x) >> 32);
            int k = (hx & 0x7FF0_0000) >> 20;		/* extract exponent */
            if (k == 0) 
            {				/* 0 or subnormal x */
                if ((lx | (hx & 0x7FFF_FFFF)) == 0)
                {
                    return x; /* +-0 */
                }
        	    x *= 1.80143985094819840000e+16;
        	    hx = (int)(asulong(x) >> 32);
        	    k = ((hx & 0x7FF0_0000) >> 20) - 54;
                if (n < -50000) 
                {
                    return 1.0e-300 * x; 	/*underflow*/
                }
        	}
            if (k == 0x07FF) 
            {
                return 2 * x;
            }
            k += n;

            if (k > 0x07FE) 
            { 
                return 1.0e+300 * copysign(1.0e+300, x); /* overflow  */
            }
            if (k > 0) 				/* normal result */
        	{
                x = asdouble((uint)asulong(x) | (long)(((hx & unchecked((int)0x800F_FFFF)) | (k << 20)) << 32));
                return x;
            }
            if (k <= -54)
            {
                if (n > 50000) 	/* in case integer overflow in n+k */
                {
        	        return 1.0e+300 * copysign(1.0e+300, x);	/*overflow*/
                }
        	    else
                {
                    return 1.0e-300 * copysign(1.0e-300, x); 	/*underflow*/
                }
            }
            k += 54;				/* subnormal result */
            x = asdouble((uint)asulong(x) | (long)(((hx & unchecked((int)0x800F_FFFF)) | (k << 20)) << 32));
            return x * 5.55111512312578270212e-17;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked scalbn(quadruple.ConstChecked x, int n)
        {
            ulong lx = x.Value.value.lo64;
            ulong hx = x.Value.value.hi64;
        	ulong k;
            k = (hx >> 48) & 0x7fff;		/* extract exponent */
            if (!(x.Promise.NonZero && x.Promise.NotSubnormal) 
             && k == 0)
            {				/* 0 or subnormal x */
                if ((lx | (hx & 0x7ffffffffffffffful)) == 0)
                {
                    return x; /* +-0 */
                }
        	    x *= new quadruple(0, 0x4071000000000000);
        	    hx = x.Value.value.hi64;
        	    k = ((hx >> 48) & 0x7fff) - 114;
        	}
            if (!(x.Promise.NotInf && x.Promise.NotNaN) 
             && k == 0x7fff)
            {
                return x;
            }
        	if (n < -50000)  /*underflow*/
            {
                return copysign(tinyQuadruple * tinyQuadruple, x);
            }
            if ((n > 50000) | (k + (ulong)(long)n > 0x7ffe)) /* overflow  */
            {
                return copysign(hugeQuadruple * hugeQuadruple, x);
            }

        	/* Now k and n are bounded we know that k = k+n does not
        	   overflow.  */
            k += (ulong)(long)n;
            if ((long)k > 0) 				/* normal result */
            {
                return new quadruple(x.Value.value.lo64, (hx & 0x8000fffffffffffful) | (k << 48));
            }
            if ((long)k <= -114)/*underflow*/
            {
        	    return copysign(tinyQuadruple * tinyQuadruple, x); 
            }

            k += 114;				/* subnormal result */
            x = new quadruple(x.Value.value.lo64, (hx & 0x8000fffffffffffful) | (k << 48));
            return x * new quadruple(0, 0x3F8D000000000000);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked ldexp(quadruple.ConstChecked value, int exp)
        {
        	if (!(value.Promise.NotNaN && value.Promise.NotInf) 
             && (!isfinite(value) | value == 0))
            {
                return value + value;
            }

        	return scalbn(value, exp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked frexp(quadruple.ConstChecked x, out int e)
        {
        	ulong ix = x.Value.value.hi64 & 0x7ffffffffffffffful;
        	e = 0;
        	if (!(x.Promise.NotNaN && x.Promise.NotInf)
             && ix >= 0x7fff000000000000ul | ((ix | x.Value.value.lo64) == 0))
            {
                return x + x;
            }
        	if (!x.Promise.NotSubnormal
             && ix < 0x0001000000000000ul)
            {
        	    x.Value *= new quadruple(0, 0x4071000000000000);
        	    ix = x.Value.value.hi64 & 0x7ffffffffffffffful;
        	    e = -114;
        	}
        	e += (int)(ix >> 48) - 16382;
        	x.Value = new quadruple(x.Value.value.lo64, (x.Value.value.hi64 & 0x8000fffffffffffful) | 0x3ffe000000000000ul);
            return x;
        }






        
        
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple log1p(quadruple xm1)
        {
            quadruple R5 = "-8.828896441624934385266096344596648080902E-1";
            quadruple R4 = "8.057002716646055371965756206836056074715E1";
            quadruple R3 = "-2.024301798136027039250415126250455056397E3";
            quadruple R2 = "2.048819892795278657810231591630928516206E4";
            quadruple R1 = "-8.977257995689735303686582344659576526998E4";
            quadruple R0 = "1.418134209872192732479751274970992665513E5";
            quadruple S5 = "-1.186359407982897997337150403816839480438E2";
            quadruple S4 = "3.998526750980007367835804959888064681098E3";
            quadruple S3 = "-5.748542087379434595104154610899551484314E4";
            quadruple S2 = "4.001557694070773974936904547424676279307E5";
            quadruple S1 = "-1.332535117259762928288745111081235577029E6";
            quadruple S0 = "1.701761051846631278975701529965589676574E6";
            quadruple C1 = "6.93145751953125E-1";
            quadruple C2 = "1.428606820309417232121458176568075500134E-6";
            quadruple sqrth = "0.7071067811865475244008443621048490392848";
            quadruple P12 = "1.538612243596254322971797716843006400388E-6";
            quadruple P11 = "4.998469661968096229986658302195402690910E-1";
            quadruple P10 = "2.321125933898420063925789532045674660756E1";
            quadruple P9 = "4.114517881637811823002128927449878962058E2";
            quadruple P8 = "3.824952356185897735160588078446136783779E3";
            quadruple P7 = "2.128857716871515081352991964243375186031E4";
            quadruple P6 = "7.594356839258970405033155585486712125861E4";
            quadruple P5 = "1.797628303815655343403735250238293741397E5";
            quadruple P4 = "2.854829159639697837788887080758954924001E5";
            quadruple P3 = "3.007007295140399532324943111654767187848E5";
            quadruple P2 = "2.014652742082537582487669938141683759923E5";
            quadruple P1 = "7.771154681358524243729929227226708890930E4";
            quadruple P0 = "1.313572404063446165910279910527789794488E4";
            quadruple Q11 = "4.839208193348159620282142911143429644326E1";
            quadruple Q10 = "9.104928120962988414618126155557301584078E2";
            quadruple Q9 = "9.147150349299596453976674231612674085381E3";
            quadruple Q8 = "5.605842085972455027590989944010492125825E4";
            quadruple Q7 = "2.248234257620569139969141618556349415120E5";
            quadruple Q6 = "6.132189329546557743179177159925690841200E5";
            quadruple Q5 = "1.158019977462989115839826904108208787040E6";
            quadruple Q4 = "1.514882452993549494932585972882995548426E6";
            quadruple Q3 = "1.347518538384329112529391120390701166528E6";
            quadruple Q2 = "7.777690340007566932935753241556479363645E5";
            quadruple Q1 = "2.626900195321832660448791748036714883242E5";
            quadruple Q0 = "3.940717212190338497730839731583397586124E4";

            quadruple x, y, z, r, s;
            int hx;
            int e;
        
            hx = (int)(xm1.value.hi64 >> 32);
            if ((hx & 0x7FFF_FFFF) >= 0x7FFF_0000)
            {
                return xm1 + abs(xm1);
            }
            if (xm1 == 0)
            {
                return xm1;
            }
        
            if ((hx & 0x7FFF_FFFF) < 0x3F8E_0000)
            {
                if ((int)xm1 == 0)
                {
                    return xm1;
                }
            }
        
            if (xm1 >= new quadruple(0, 0x4070_0000_0000_0000))
            {
                x = xm1;
            }
            else
            { 
                x = xm1 + 1;
            }
        
            if (x <= 0)
            {
                if (x == 0)
                {
                    return quadruple.NegativeInfinity;
                }
                else
                {
                    return quadruple.NaN;
                }
            }

            x = frexp(x, out e);
        
            if ((e > 2) || (e < -2))
            {
                if (x < sqrth)
        	    {
        	        e -= 1;
        	        z = x - 0.5;
        	        y = quadruple.fmadd(0.5, z, 0.5);
        	    }
                else
        	    {
        	        z = x - 0.5;
        	        z -= 0.5;
        	        y = quadruple.fmadd(0.5, x, 0.5);
        	    }
                x = z / y;
                z = square(x);
                r = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(R5, z, R4), z, R3), z, R2), z, R1), z, R0);
                s = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(z + S5, z, S4), z, S3), z, S2), z, S1), z, S0);
                z = x * (z * r / s);
                z = quadruple.fmadd(e, C2, z);
                z = z + x;
                z = quadruple.fmadd(e, C1, z);
                return z;
            }
        
            if (x < sqrth)
            {
                e--;
                if (e != 0)
                {
                    x = 2 * x - 1;
                }
                else
                {
                    x = xm1;
                }
            }
            else
            {
                if (e != 0)
                {
                    x = x - 1;
                }
                else
                {
                    x = xm1;
                }
            }

            z = square(x);
            r = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(P12, x, P11), x, P10), x, P9), x, P8), x, P7), x, P6), x, P5), x, P4), x, P3), x, P2), x, P1), x, P0);
            s = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(x + Q11, x, Q10), x, Q9), x, Q8), x, Q7), x, Q6), x, Q5), x, Q4), x, Q3), x, Q2), x, Q1), x, Q0);
            y = x * (z * r / s);
            y = quadruple.fmadd(e, C2, y);
            z = quadruple.fmadd(-0.5, z, y);
            z = z + x;
            z = quadruple.fmadd(e, C1, z);
            return z;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int kernel_rem_pio2(double* x, double* y, int e0, int nx, int prec)
        {
	        int jz, jx, jv, jp, jk, carry, n, i, j, k, m, q0, ih;
	        double z, fw;

            int* iq    = stackalloc int   [20];
            double* f  = stackalloc double[20];
            double* fq = stackalloc double[20];
            double* q  = stackalloc double[20];

	        jk = 2 + prec + tobyte(prec > 2);
	        jp = jk;

	        jx = nx - 1;
	        jv = max((e0 - 3) / 24, 0);
	        q0 = e0 - 24 * (jv + 1);

	        j = jv - jx; 
            m = jx + jk;
	        for(i = 0; i <= m; i++, j++) 
            {
                f[i] = (j < 0) ? 0 : LUT.QUADRUPLE.ipio2(j);
            }

	        for (i = 0; i <= jk; i++) 
            {
	            for(j = 0, fw = 0.0; j <= jx; j++) 
                {
                    fw = mad(x[j], f[jx + i - j], fw); 
                    q[i] = fw;
                }
	        }

	        jz = jk;
        recompute:
	        for(i = 0, j = jz, z = q[jz]; j > 0; i++, j--) 
            {
	            fw    =  (int)(5.96046447753906250000e-08 * z);
	            iq[i] =  (int)mad(-1.67772160000000000000e+07, fw, z);
	            z     =  q[j - 1] + fw;
	        }

	        z  = scalbn(z, q0);
	        z -= 8.0 * floor(z * 0.125);
	        n  = (int)z;
	        z -= n;
	        ih = 0;
	        if (q0 > 0) 
            {
	            i  = (iq[jz - 1] >> (24 - q0)); 
                n += i;
	            iq[jz - 1] -= i << (24 - q0);
	            ih = iq[jz - 1] >> (23 - q0);
	        }
	        else if (q0 == 0) 
            {
                ih = iq[jz - 1] >> 23;
            }
	        else if (z >= 0.5) 
            {
                ih = 2;
            }

	        if (ih > 0) 
            {
	            n += 1; 
                carry = 0;
	            for(i = 0; i < jz; i++) 
                {
	        	    j = iq[i];
	        	    if (carry == 0) 
                    {
	        	        if (j != 0) 
                        {
	        		        carry = 1; 
                            iq[i] = 0x0100_0000 - j;
	        	        }
	        	    } 
                    else
                    {
                        iq[i] = 0x00FF_FFFF - j;
                    }
	            }
	            if (Hint.Unlikely(q0 > 0)) 
                {
	                switch(q0) 
                    {
	                    case 1:  iq[jz - 1] &= 0x007F_FFFF; break;
	            	    case 2:  iq[jz - 1] &= 0x003F_FFFF; break;
                        default:                            break;
	                }
	            }
	            if (ih == 2) 
                {
	        	    z = 1 - z;
	        	    if (carry != 0) 
                    {
                        z -= scalbn(1, q0);
                    }
	            }
	        }

	        if (z == 0) 
            {
	            j = 0;
	            for (i = jz - 1; i >= jk; i--) 
                {
                    j |= iq[i];
                }
	            if (j == 0) 
                {
	        	    for(k = 1; iq[jk - k] == 0; k++);

	        	    for(i = jz + 1; i <= jz + k; i++) 
                    {
	        	        f[jx + i] = LUT.QUADRUPLE.ipio2(jv + i);
	        	        for(j = 0, fw = 0.0; j <= jx; j++) 
                        {
                            fw = mad(x[j], f[jx + i - j], fw);
                        }
	        	        q[i] = fw;
	        	    }
	        	    jz += k;
	        	    goto recompute;
	            }
	        }

	        if (z == 0.0) 
            {
	            jz -= 1; 
                q0 -= 24;
	            while(iq[jz] == 0) 
                { 
                    jz--; 
                    q0 -= 24;
                }
	        } 
            else 
            {
	            z = scalbn(z, -q0);
	            if (z >= 1.67772160000000000000e+07) 
                {
	        	    fw = (double)((int)(5.96046447753906250000e-08 * z));
	        	    iq[jz] = (int)mad(-1.67772160000000000000e+07, fw, z);
	        	    jz += 1; 
                    q0 += 24;
	        	    iq[jz] = (int)fw;
	            }
                else 
                {
                    iq[jz] = (int)z;
                }
	        }

	        fw = scalbn(1, q0);
	        for(i = jz; i >= 0; i--) 
            {
	            q[i] = fw * iq[i]; 
                fw *= 5.96046447753906250000e-08;
	        }

	        for(i = jz; i >= 0; i--)
            {
	            for(fw = 0.0, k = 0; (k <= jp) & (k <= jz - i); k++) 
                {
                    fw = mad(LUT.QUADRUPLE.PIo2(k), q[i + k], fw);
                }
	            fq[jz - i] = fw;
	        }

	        switch(prec) 
            {
	            case 0:
                {
	        	    fw = 0.0;
	        	    for (i = jz; i >= 0; i--) 
                    {
                        fw += fq[i];
                    }
	        	    y[0] = (ih == 0) ? fw : -fw;
	        	    break;
                }
	            case 1:
	            case 2:
                {
	        	    fw = 0.0;
	        	    for (i = jz; i >= 0; i--)
                    {
                        fw += fq[i];
                    }
	        	    y[0] = (ih == 0)? fw : -fw;
	        	    fw = fq[0] - fw;
	        	    for (i = 1; i <= jz; i++)
                    {
                        fw += fq[i];
                    }
	        	    y[1] = (ih == 0)? fw : -fw;
	        	    break;
                }
	            case 3:
                {
	        	    for (i = jz; i > 0; i--) 
                    {
		                double fv = fq[i - 1] + fq[i];
		                fq[i]    += fq[i - 1] - fv;
		                fq[i - 1] = fv;
		            }
		            for (i = jz; i > 1; i--) 
                    {
		                double fv = fq[i - 1] + fq[i];
		                fq[i]    += fq[i - 1] - fv;
		                fq[i - 1] = fv;
		            }
		            for (fw = 0.0, i = jz; i >= 2; i--)
                    {
                        fw += fq[i];
                    }
		            if (ih == 0)
                    {
		                y[0] = fq[0]; 
                        y[1] = fq[1]; 
                        y[2] = fw;
		            } 
                    else 
                    {
		                y[0] = -fq[0]; 
                        y[1] = -fq[1]; 
                        y[2] = -fw;
		            }

                    break;
                }
	        }

	        return n & 7;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static int rem_pio2(quadruple.ConstChecked x, quadruple* y)
        {
            quadruple.ConstChecked PI_2_1  = new quadruple(0x8469_898C_C517_01B8, 0x3FFF_921F_B544_42D1);
            quadruple.ConstChecked PI_2_1t = new quadruple(0xA67C_C740_20BB_EA64, 0x3F8C_CD12_9024_E088);

            quadruple.ConstChecked z, w, t;
            double* tx = stackalloc double[8];
            long exp, n, ix;
        
            long hx = (long)x.Value.value.hi64;
            ulong lx = x.Value.value.lo64;
        
            ix = hx & 0x7FFF_FFFF_FFFF_FFFF;
            if (ix <= 0x3FFE_921F_B544_42D1)
            {
                y[0] = x;
                y[1] = 0;
                return 0;
            }
        
            if (ix < 0x4000_2D97_C7F3_321D)
            {
                if (hx > 0)
        	    {
        	        z = x - PI_2_1;
        	        y[0] = z - PI_2_1t;
        	        y[1] = (z - y[0]) - PI_2_1t;
        	        return 1;
        	    }
                else
                {
        	        z = x + PI_2_1;
        	        y[0] = z + PI_2_1t;
        	        y[1] = (z - y[0]) + PI_2_1t;
        	        return -1;
        	    }
            }
        
            if (ix >= 0x7FFF_0000_0000_0000)	/* x is +=oo or NaN */
            {
                y[0] = x - x;
                y[1] = y[0];
                return 0;
            }
        
            exp = (ix >> 48) - 16383 - 23;
        
            tx [0] = (double)(((ix >> 25) & 0x007F_FFFF) | 0x0080_0000);
            tx [1] = (double)((ix >> 1) & 0x00FF_FFFF);
            tx [2] = (double)(((ix << 23) | (long)(lx >> 41)) & 0x00FF_FFFF);
            tx [3] = (double)((lx >> 17) & 0x00FF_FFFF);
            tx [4] = (double)((lx << 7) & 0x00FF_FFFF);
        
            n = kernel_rem_pio2(tx, tx + 5, (int)exp, (lx & (0x00FF_FFFF >> 7)) != 0 ? 5 : 4, 3);
        
            t = (quadruple)tx[6] + (quadruple)tx[7];
            w = (quadruple)tx[5];
        
            if (hx >= 0)
            {
                y[0] = w + t;
                y[1] = t - (y[0] - w);
                return (int)n;
            }
            else
            {
                y[0] = -(w + t);
                y[1] = -t - (y[0] + w);
                return (int)-n;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static quadruple.ConstChecked expm1(quadruple.ConstChecked x)
        {
            quadruple.ConstChecked P0     = new quadruple(0x042C_1EAC_2C0A_7A5E, 0x401B_18B7_4DB8_E974);
            quadruple.ConstChecked P1     = new quadruple(0x3197_6B98_B3E6_97C3, 0xC018_B49E_5C6B_648D);
            quadruple.ConstChecked P2     = new quadruple(0x6EFA_8978_BD75_C0A5, 0x4016_10F7_ED9C_DAE6);
            quadruple.ConstChecked P3     = new quadruple(0x83C3_9EA4_00D8_94A2, 0xC012_602B_68AE_F25D);
            quadruple.ConstChecked P4     = new quadruple(0xE75E_048A_64C6_89C0, 0x400E_65BB_3FE0_55CC);
            quadruple.ConstChecked P5     = new quadruple(0x4CBE_8D31_2EB3_4724, 0xC009_AD31_70BE_A319);
            quadruple.ConstChecked P6     = new quadruple(0x5CB7_B3AF_79C1_CE70, 0x4004_601A_CDF8_F4A3);
            quadruple.ConstChecked P7     = new quadruple(0x1E1A_0A08_790A_E2CE, 0xBFFD_F49B_524A_2C73);
            quadruple.ConstChecked Q0     = new quadruple(0x0642_2E02_420F_B8CE, 0x401D_A512_F495_5E2E);
            quadruple.ConstChecked Q1     = new quadruple(0xF5B9_DF5A_647E_501B, 0xC01C_7644_DCF2_F4CB);
            quadruple.ConstChecked Q2     = new quadruple(0x900A_26E6_C446_0F28, 0x401A_3433_DA9E_D469);
            quadruple.ConstChecked Q3     = new quadruple(0xEFC2_E1EB_CB9F_9029, 0xC017_342D_E8BA_7627);
            quadruple.ConstChecked Q4     = new quadruple(0x535A_F72A_52FA_D173, 0x4013_9ADE_0BAA_C376);
            quadruple.ConstChecked Q5     = new quadruple(0x5E51_381C_74CA_5BAE, 0xC00F_779B_1D90_DD70);
            quadruple.ConstChecked Q6     = new quadruple(0xC5B2_A088_5CB5_703E, 0x400A_CE36_E0E3_90D4);
            quadruple.ConstChecked Q7     = new quadruple(0xAC49_24EA_19C2_1ECB, 0xC005_6017_F7F4_F644);
            quadruple.ConstChecked C1     = new quadruple(0x0000_0000_0000_0000, 0x3FFE_62E4_0000_0000);
            quadruple.ConstChecked C2     = new quadruple(0x9E3B_3980_3F2F_6AF4, 0x3FEB_7F7D_1CF7_9ABC);
            quadruple.ConstChecked minarg = new quadruple(0x90B9_FF9D_97E6_C709, 0xC005_3C13_3AB1_6DB9);
            quadruple.ConstChecked big    = new quadruple(0, 0xBFFF_0000_0000_0000);
            quadruple.ConstChecked fence  = new quadruple(0, 0x3F8E_0000_0000_0000);

            quadruple.ConstChecked px, qx, xx;
        
            long ix = (long)x.Value.value.hi64;
            ix &= 0x7FFF_FFFF_FFFF_FFFF;
            if ((ix < 0) 
              & (ix >= 0x4006_0000_0000_0000))
            {
                return exp(x);
            }
            if (ix >= 0x7FFF_0000_0000_0000)
            {
                if (x == quadruple.NegativeInfinity)
                {
                    return -1;
                }

                return quadruple.NaN;
            }
            if (quadruple.IsZero(x))
            {
                return x;
            }
            if (x < minarg)
            {
                return big;
            }
            if (abs(x) < fence)
            {
                return x;
            }
        
            xx = C1 + C2;
            px = floor(0.5 + x / xx);
            int k = (int)px.Value;
            x = quadruple.fnmadd(px, C1, x);
            x = quadruple.fnmadd(px, C2, x);
        
            px = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(P7, x, P6), x, P5), x, P4), x, P3), x, P2), x, P1), x, P0) * x;
            qx = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(x + Q7, x, Q6), x, Q5), x, Q4), x, Q3), x, Q2), x, Q1), x, Q0);
        
            xx = square(x);
            qx = x + quadruple.fmadd(xx, px / qx, 0.5 * xx);
            px = ldexp(1, k);
            return quadruple.fmadd(px, qx, px - 1);
        }
    }
}
