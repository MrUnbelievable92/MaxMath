using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        public static implicit operator quadruple(string value)
        {
            return Parse(value);
        }


        public static bool TryParse(string s, out quadruple q)
        {
            return !isnan(q = Parse(s));
        }

        public static quadruple Parse(string s)
        {
            static UInt128 RoundRightShift(BigInteger value, int shift)
            {
                if (shift <= 0)
                {
                    return (UInt128)(value << -shift);
                }
            
                BigInteger shifted = value >> shift;
                BigInteger guardMask = BigInteger.One << (shift - 1);
                bool guard = (value & guardMask) != 0;
                bool sticky = (value & (guardMask - 1)) != 0;
                bool lsb = (shifted & 1) != 0;
            
                if (guard & (sticky | lsb))
                {
                    shifted += 1;
                }
            
                return (UInt128)shifted;
            }

            static quadruple FromComponents(UInt128 sig, int exp, bool sign)
            {
                UInt128 SIGNIFICAND_MASK = bitmask128((ulong)MANTISSA_BITS);
                UInt128 SIGNBIT_MASK = (UInt128)1 << 127;
                UInt128 EXPONENT_MASK = ~SIGNIFICAND_MASK ^ SIGNBIT_MASK;

                UInt128 r = new UInt128(sig.lo64, (sig.hi64 & ~EXPONENT_MASK.hi64) | toulong(sign) << 63);

                if (exp == MIN_UNBIASED_EXPONENT)
                {
                    ;
                }
                else if (exp != short.MaxValue)
                {
                    r |= (UInt128)(ushort)(exp - EXPONENT_BIAS) << MANTISSA_BITS;
                }
                else
                {
                    r |= (UInt128)(ushort)short.MaxValue << MANTISSA_BITS;
                }

                return asquadruple(r);
            }

            s = s.Trim();
            if (s.StartsWith('+'))
            {
                s = s.Substring(1);
            }

            switch (s)
            {
                case "NaN": return NaN;
                case "Infinity": return PositiveInfinity;
                case "-Infinity": return NegativeInfinity;
            }

            Match match = Regex.Match(s, @"^(-)?(\d+)(?:\.(\d+))?(?:[Ee]([+-]?\d+))?$");
            if (!match.Success)
            {
                return NaN;
            }

            if (match.Groups[4].Success)
            {
                int exponent = int.Parse(match.Groups[4].Value);
            
                string integer = match.Groups[2].Value;
                string fraction = match.Groups[3].Success ? match.Groups[3].Value : string.Empty;
                string digits = integer + fraction;
            
                int decimalPos = integer.Length + exponent;
            
                StringBuilder builder = new StringBuilder(53);
            
                if (decimalPos <= 0)
                {
                    builder.Append("0.");
                    builder.Append('0', -decimalPos);
                    builder.Append(digits);
                }
                else if (decimalPos >= digits.Length)
                {
                    builder.Append(digits);
                    builder.Append('0', decimalPos - digits.Length);
                }
                else
                {
                    builder.Append(digits);
                    builder.Insert(decimalPos, '.');
                }
            
                if (match.Groups[1].Success)
                {
                    builder.Insert(0, '-');
                }
            
                return Parse(builder.ToString());
            }

            BigInteger wholePart = BigInteger.Parse(match.Groups[2].Value);
            BigInteger fracPart = match.Groups[3].Success ? BigInteger.Parse(match.Groups[3].Value) : 0;
            int zExponent = match.Groups[3].Value.TakeWhile(digit => digit == '0').Count();

            int resultExponent;
            if ((wholePart == 0) & (fracPart == 0))
            {
                resultExponent = EXPONENT_BIAS + 1;
            }
            else
            {
                resultExponent = (int)wholePart.Log2();
                int wholeDiff = (int)wholePart.GetBitLength() - 116;
                if (wholeDiff > 0)
                {
                    wholePart >>= wholeDiff;
                }
                else if (wholeDiff < 0)
                {
                    wholePart <<= -wholeDiff;
                }
            }

            bool resultSign = match.Groups[1].Value.StartsWith('-');
            BigInteger resultSignificand = wholePart;
            if (fracPart == 0)
            {
                return FromComponents((UInt128)(resultSignificand >> 3), resultExponent, resultSign);
            }
            else
            {
                int log10Value = (int)floor(BigInteger.Log10(fracPart)) + 1;
                if (wholePart == 0)
                {
                    resultExponent = (int)floor(-BigInteger.Log(BigInteger.Pow(10, zExponent + 1), 2));
                }

                BigInteger pow10 = BigInteger.Pow(10, log10Value + zExponent);
                int binIndex = 114 - resultExponent;
                while ((binIndex > 0) & (fracPart != 0))
                {
                    fracPart <<= 1;
                    if (fracPart / pow10 == 1)
                    {
                        resultSignificand |= BigInteger.One << binIndex;
                    }
                    fracPart %= pow10;
                    --binIndex;
                }
                
                resultSignificand |= (UInt128)BigInteger.Min(fracPart, 1);
                    
                short normDist = (short)(lzcnt((UInt128)(resultSignificand >> 3)) - 15);
                if (normDist > 0)
                {
                    resultSignificand <<= normDist;
                }
                else if (normDist < 0)
                {
                    int shiftAmt = -normDist;
                    BigInteger shiftedOutMask = (BigInteger.One << shiftAmt) - 1;
                    bool lostBitsNonzero = (resultSignificand & shiftedOutMask) != 0;
                    resultSignificand >>= shiftAmt;
                    if (lostBitsNonzero)
                    {
                        resultSignificand |= 1;
                    }
                }
                resultExponent -= normDist;
                if (resultExponent < MIN_UNBIASED_EXPONENT)
                {
                    int expnDiff = MIN_UNBIASED_EXPONENT - resultExponent + 3;
                    UInt128 rounded = RoundRightShift(resultSignificand, expnDiff);
                
                    if (rounded == (UInt128)1 << MANTISSA_BITS)
                    {
                        return asquadruple(rounded | ((UInt128)toulong(resultSign) << 127));
                    }
                    return FromComponents(rounded, MIN_UNBIASED_EXPONENT, resultSign);
                }
                else
                {
                    UInt128 lsb    = ((UInt128)resultSignificand >> 3) & 1;
                    UInt128 guard  = ((UInt128)resultSignificand >> 2) & 1;
                    UInt128 round_ = ((UInt128)resultSignificand >> 1) & 1;
                    UInt128 sticky = (UInt128)resultSignificand & 1;
                
                    if ((guard & (round_ | sticky | lsb)) == 1)
                    {
                        resultSignificand += 8;
                        if ((resultSignificand >> 116) != 0)
                        {
                            resultSignificand >>= 1;
                            resultExponent += 1;
                        }
                    }

                    if (resultExponent == MIN_UNBIASED_EXPONENT)
                    {
                        return asquadruple(((UInt128)(resultSignificand >> 3)) | ((UInt128)toulong(resultSign) << 127));
                    }
                    else
                    {
                        return FromComponents((UInt128)(resultSignificand >> 3), resultExponent, resultSign);
                    }
                }
            }
        }
    }
}