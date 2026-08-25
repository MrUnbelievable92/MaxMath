using System.Runtime.CompilerServices;
using Unity.Burst;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple.ConstChecked Remainder(quadruple.ConstChecked left, quadruple.ConstChecked right)
        {
            FloatingPointPromise<quadruple> finalPromise = default(FloatingPointPromise<quadruple>);
            //finalPromise |= left.Promise.Negative && right.Promise.Negative ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Positive && right.Promise.Positive ? FloatingPointPromise<quadruple>.POSITIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Positive && right.Promise.Negative ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;
            //finalPromise |= left.Promise.Negative && right.Promise.Positive ? FloatingPointPromise<quadruple>.NEGATIVE : Promise.Nothing;

			if (COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low)
			{
				return fnmadd(trunc(left / right), right, left);
			}

			ulong lx = left.Value.value.lo64;
			ulong ly = right.Value.value.lo64;
			long hx = (long)left.Value.value.hi64;
			long hy = (long)right.Value.value.hi64;

			long sign = hx & (1L << 63);
			hx ^= sign;
			hy &= 0x7FFF_FFFF_FFFF_FFFFL;

			if ((IsZero(right) | isinf(left))
		      | (isnan(left) | isnan(right)))
			{
			    return NaN;
			}
			if (hx <= hy) 
			{
			    if (hx < hy
				  | lx < ly) 
				{
					return left;
				}
			    if (lx == ly)
				{
					return new quadruple.ConstChecked(new quadruple(0, (ulong)sign), finalPromise);
				}
			}
			
			long ix;
			if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
			 && hx < 0x0001_0000_0000_0000L) 
			{	
				ix = (hx == 0 ? -16431 : -16382)
				   - lzcnt(hx == 0 ? lx : hx << EXPONENT_BITS);
			} 
			else 
			{
				ix = (hx >> MANTISSA_BITS_HI64) - 0x3FFF;
			}
			
			long iy;
			if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO 
			 && hy < 0x0001_0000_0000_0000L) 
			{	
				iy = (hy == 0 ? -16431 : -16382)
				   - lzcnt(hy == 0 ? ly : hy << EXPONENT_BITS);
			} 
			else
			{
				iy = (hy >> MANTISSA_BITS_HI64) - 0x3FFF;
			}

			UInt128 X = new UInt128(lx, (ulong)hx); 
			UInt128 Y = new UInt128(ly, (ulong)hy);
			if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO
			 || ix >= -16382)
			{
			    X = new UInt128(X.lo64, 0x0001000000000000L | (0x0000FFFFFFFFFFFFL & X.hi64));
			}
			else 
			{
			    X <<= (int)(-16382 - ix);
			}
			if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO
			 || iy >= -16382)
			{
			    Y = new UInt128(Y.lo64, 0x0001000000000000L | (0x0000FFFFFFFFFFFFL & Y.hi64));
			}
			else 
			{
			    Y <<= (int)(-16382 - iy);
			}

			X = asm128.__usf__loop_rem128to256x128shl127x15(X, Y, ix - iy);
			
			if (X == 0)
			{
			    return new quadruple.ConstChecked(new quadruple(0, (ulong)sign), finalPromise);
			}
			
			long normalShift = lzcnt(X) - EXPONENT_BITS;
			long candidateIy = iy - normalShift;
			
			if (candidateIy >= -16382)
			{
			    X <<= (int)normalShift;
			    hx = (long)((X.hi64 - (1ul << MANTISSA_BITS_HI64)) | ((ulong)(candidateIy + 16383) << MANTISSA_BITS_HI64));
			}
			else
			{
			    long netShift = iy + 16382;
			    X = netShift >= 0 ? (X << (int)netShift) : (X >> (int)(-netShift));
			    hx = (long)X.hi64;
			}

			return new quadruple.ConstChecked(new quadruple(X.lo64, (ulong)(hx | sign)), finalPromise);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple operator % (quadruple left, quadruple right) => Remainder(left, right);
    }


    unsafe public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple fmod(quadruple x, quadruple y)
        {
            return x % y;
        }
    }
}
