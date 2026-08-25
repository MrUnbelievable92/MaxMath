using System.Runtime.CompilerServices;

using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    public struct doubledouble
    {
        private double Upper;
        private double Lower;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(byte value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte(doubledouble value) => (byte)(double)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(ushort value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(doubledouble value) => (ushort)(double)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(uint value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(doubledouble value) => (uint)(double)value;












        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(quarter value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(doubledouble value) => (quarter)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(half value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(doubledouble value) => (half)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(float value) => (doubledouble)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float(doubledouble value) => (float)(double)value;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator doubledouble(double value)
        {
            return new doubledouble { Upper = value, Lower = 0 };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double(doubledouble value)
        {
            return value.Lower + value.Upper;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator doubledouble(quadruple value)
        {
            double hi = (double)value;
            quadruple r = value - hi;
            double lo = (double)r;

            return new doubledouble { Upper = hi, Lower = lo };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quadruple(doubledouble value)
        {
            return (quadruple)value.Upper + (quadruple)value.Lower;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static doubledouble __split(double x)
        {
            ulong MASK = bitmask64((ulong)F64_MANTISSA_BITS / 2 + 1);
            double upper = asdouble(andnot(asulong(x), MASK));
            
            return new doubledouble { Upper = upper, Lower = x - upper };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static doubledouble __mul12(double x, double y)
        {
            doubledouble __x = __split(x);
            doubledouble __y = __split(y);

            double p = __x.Upper * __y.Upper;
            double q = mad(__x.Upper, __y.Lower, __x.Lower * __y.Upper);
            double pq = p + q;

            return new doubledouble { Upper = pq, Lower = mad(__x.Lower, __y.Lower, (p - pq) + q) };
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator + (doubledouble value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator - (doubledouble value)
        {
            return new doubledouble { Upper = -value.Upper, Lower = -value.Lower };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator + (doubledouble left, doubledouble right)
        {
            double R = left.Upper + right.Upper;

            double r0 = ((((left.Upper - R) + right.Upper) + right.Lower) + left.Lower);
            double r1 = ((((right.Upper - R) + left.Upper) + left.Lower) + right.Lower);

            double r = select(r1, r0, abs(left.Upper) > abs(right.Upper));

            double C = R + r;
            double c = (R - C) + r;

            return new doubledouble { Upper = C, Lower = c };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator - (doubledouble left, doubledouble right)
        {
            double R = left.Upper - right.Upper;
            
            double r0 = ((((left.Upper - R) - right.Upper) - right.Lower) + left.Lower);
            double r1 = ((((-right.Upper - R) + left.Upper) + left.Lower) - right.Lower);

            double r = select(r1, r0, abs(left.Upper) > abs(right.Upper));

            double C = R + r;
            double c = (R - C) + r;

            return new doubledouble { Upper = C, Lower = c };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator * (doubledouble left, doubledouble right)
        {
            doubledouble t = __mul12(left.Upper, right.Upper);
            double c = mad(left.Upper, right.Lower, mad(left.Lower, right.Upper, t.Lower));
            
            double hi = t.Upper + c;
            double lo = (t.Upper - hi) + c;

            return new doubledouble { Upper = hi, Lower = lo };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble operator / (doubledouble left, doubledouble right)
        {
            double __hi = left.Upper / right.Upper;

            doubledouble t = __mul12(__hi, right.Upper);
            double l = mad(-right.Lower, __hi, ((left.Upper - t.Upper) - t.Lower) + left.Lower) / right.Upper;

            double hi = __hi + l; 
            double lo = (__hi - hi) + l;

            return new doubledouble { Upper = hi, Lower = lo };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble SquareRoot(doubledouble value)
        {
            doubledouble guess = sqrt(value.Upper);

            return 0.5 * (guess + value / guess);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble min_unsafe(doubledouble x, doubledouble y)
        {
            bool takeX = x.Upper < y.Upper | (x.Upper == y.Upper & x.Lower < y.Lower);

            return new doubledouble { Upper = select(y.Upper, x.Upper, takeX), 
                                      Lower = select(y.Lower, x.Lower, takeX) };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static doubledouble max_unsafe(doubledouble x, doubledouble y)
        {
            bool takeX = x.Upper > y.Upper | (x.Upper == y.Upper & x.Lower > y.Lower);

            return new doubledouble { Upper = select(y.Upper, x.Upper, takeX), 
                                      Lower = select(y.Lower, x.Lower, takeX) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(doubledouble x)
        {
            return math.ispow2(x.Upper) & x.Lower == 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(doubledouble x)
        {
            return math.ispow2mag(x.Upper) & x.Lower == 0;
        }
        
        public override readonly string ToString()
        {
            return ((quadruple)this).ToString();
        }
        
        public static doubledouble Parse(string value)
        {
            return (doubledouble)quadruple.Parse(value);
        }
        
        public static bool TryParse(string value, out doubledouble result)
        {
            bool success;

            result = (success = quadruple.TryParse(value, out quadruple result128)) 
                   ? (doubledouble)result128 
                   : 0;

            return success;
        }
    }
}
