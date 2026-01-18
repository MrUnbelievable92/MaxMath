using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        public static implicit operator quadruple(string value)
        {
            return Parse(value);
        }


        public static quadruple Parse(string s)
        {
            static quadruple FromComponents(UInt128 sig, int exp, bool sign)
            {
                UInt128 SIGNIFICAND_MASK = bitmask128((ulong)MANTISSA_BITS);
                UInt128 SIGNBIT_MASK = (UInt128)1 << 127;
                UInt128 EXPONENT_MASK = ~SIGNIFICAND_MASK ^ SIGNBIT_MASK;

                UInt128 r = new UInt128(sig.lo64, (sig.hi64 & ~EXPONENT_MASK.hi64) | toulong(sign) << 63);

                if (exp == EXPONENT_BIAS + 1)
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

            switch (s)
            {
                case "NaN": return NaN;
                case "Infinity": return PositiveInfinity;
                case "-Infinity": return NegativeInfinity;
            }

            Match match = Regex.Match(s, @"(\-)?(\d+)(?:\.(\d+))?(?:[E|e]([+|-]?\d+))?");
            if (!match.Success)
            {
                return NaN;
            }

            if (match.Groups[4].Success)
            {
                int qExponent = int.Parse(match.Groups[4].Value);
                string allDigits = $"{match.Groups[2].Value}{match.Groups[3].Value}";

                StringBuilder builder = new StringBuilder(53);
                if (qExponent > 0)
                {
                    if (qExponent > allDigits.Length)
                    {
                        builder.Append(allDigits);
                        builder.Append(new string('0', qExponent - allDigits.Length + 1));
                    }
                    else
                    {
                        builder.Append(allDigits);
                        builder.Insert(allDigits.Length - qExponent, '.');
                    }
                }
                else if (qExponent < 0)
                {
                    builder.Append("0.");
                    builder.Append(new string('0', -qExponent - 1));
                    builder.Append(allDigits);
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
            UInt128 resultSignificand = (UInt128)wholePart;
            if (fracPart == 0)
            {
                return FromComponents(resultSignificand >> 3, resultExponent, resultSign);
            }
            else
            {
                int log10Value = (int)floor(BigInteger.Log10(fracPart)) + 1;
                bool isSubNormal = zExponent > 4390;
                if (wholePart == 0)
                {
                    resultExponent = -(int)floor(BigInteger.Log(BigInteger.Pow(10, zExponent), 2)) + 1;
                }

                BigInteger pow10 = BigInteger.Pow(10, log10Value + zExponent);
                int binIndex = 114 - resultExponent;
                while ((binIndex > 0) & (fracPart != 0))
                {
                    fracPart <<= 1;
                    if (fracPart / pow10 == 1)
                    {
                        resultSignificand |= (UInt128)1 << binIndex;
                    }
                    fracPart %= pow10;
                    --binIndex;
                }

                // set sticky bit
                resultSignificand |= (UInt128)BigInteger.Min(fracPart, 1);

                if ((((resultSignificand & 1) |
                     ((resultSignificand >> 2) & 1)) &
                     ((resultSignificand >> 1) & 1)) == 1)
                {
                    resultSignificand++;
                }

                if (isSubNormal)
                {
                    int expnDiff = EXPONENT_BIAS + 1 - resultExponent + 3;
                    return FromComponents(resultSignificand >> expnDiff, EXPONENT_BIAS + 1, resultSign);
                }
                else
                {
                    short normDist = (short)(lzcnt(resultSignificand >> 3) - 15);
                    if (normDist > 0)
                    {
                        resultSignificand <<= normDist;
                    }
                    else if (normDist < 0)
                    {
                        resultSignificand >>= -normDist;
                    }

                    resultExponent -= normDist;

                    return FromComponents(resultSignificand >> 3, resultExponent, resultSign);
                }
            }
        }
    }
}