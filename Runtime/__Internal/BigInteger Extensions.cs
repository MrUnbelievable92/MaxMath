using System.Numerics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    public static class BigIntegerExtensions
    {
        internal static BigInteger Log2(this BigInteger value)
        {
            //uint[] bits = (uint[])typeof(BigInteger).GetField("_bits", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
            //int sign = (int)typeof(BigInteger).GetField("_sign", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
            //
            //if (bits == null)
            //{
            //    return 31 ^ lzcnt((uint)(sign | 1));
            //}
            //
            //return ((bits.Length * 32) - 1) ^ lzcnt(bits[bits.Length - 1]);

            BigInteger dec = 0 + value;
            BigInteger result = 0;
            while (dec >= 2)
            {
                dec >>= 1;
                result++;
            }

            return result;
        }

        internal static long GetBitLength(this BigInteger value)
        {
            //uint highValue;
            //int bitsArrayLength;
            //int sign = (int)typeof(BigInteger).GetField("_sign", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
            //uint[] bits = (uint[])typeof(BigInteger).GetField("_bits", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value);
            //
            //if (bits == null)
            //{
            //    bitsArrayLength = 1;
            //    highValue = (uint)(sign < 0 ? -sign : sign);
            //}
            //else
            //{
            //    bitsArrayLength = bits.Length;
            //    highValue = bits[bitsArrayLength - 1];
            //}
            //
            //long bitLength = bitsArrayLength * 32L - lzcnt(highValue);
            //
            //if ((sign >= 0)
            //  | ((bits_resetlowest(highValue)) != 0))
            //{
            //    return bitLength;
            //}
            //
            //for (int i = bitsArrayLength - 2; i >= 0; i--)
            //{
            //    if (bits[i] == 0)
            //    {
            //        continue;
            //    }
            //
            //    return bitLength;
            //}
            //
            //return bitLength - 1;

            byte[] bytes = value.ToByteArray();
            byte msb = bytes[bytes.Length - 1];
            int msbBits = 0;
            while (msb != 0)
            {
                msb >>= 1;
                msbBits++;
            }
            return (bytes.Length - 1) * 8 + msbBits;
        }

        internal static BigInteger Sqrt(this BigInteger x)
        {
            double xAsDub = (double)x;
            if (xAsDub < 8.5e37)
            {
                UInt128 vInt = (UInt128)sqrt(xAsDub);
                UInt128 v = (vInt + ((UInt128)x / vInt)) >> 1;
                return v - tobyte(square(v) > x);
            }

            if (xAsDub < 4.3322e127)
            {
                BigInteger v = (BigInteger)sqrt(xAsDub);
                v = (v + (x / v)) >> 1;
                if (xAsDub > 2e63)
                {
                    v = (v + (x / v)) >> 1;
                }
                return v - tobyte(v * v > x);
            }

            int xLen = (int)x.GetBitLength();
            int wantedPrecision = (xLen + 1) / 2;
            int xLenMod = xLen + (xLen & 1) + 1;

            long tempX = (long)(x >> (xLenMod - 63));
            double tempSqrt1 = sqrt((double)tempX);
            ulong valLong = asulong(tempSqrt1) & 0x1fffffffffffffL;
            if (valLong == 0)
            {
                valLong = 1UL << 53;
            }

            BigInteger val = ((BigInteger)valLong << 52) + (x >> xLenMod - (3 * 53)) / valLong;
            int size = 106;
            for (; size < 256; size <<= 1)
            {
                val = (val << (size - 1)) + (x >> xLenMod - (3 * size)) / val;
            }

            if (xAsDub > 4e254)
            {
                int numOfNewtonSteps = floorlog2((uint)(wantedPrecision / size)) + 2;

                int wantedSize = (wantedPrecision >> numOfNewtonSteps) + 2;
                int needToShiftBy = size - wantedSize;
                val >>= needToShiftBy;
                size = wantedSize;
                do
                {
                    int shiftX = xLenMod - (3 * size);
                    BigInteger valSqrd = (val * val) << (size - 1);
                    BigInteger valSU = (x >> shiftX) - valSqrd;
                    val = (val << size) + (valSU / val);
                    size *= 2;
                }
                while (size < wantedPrecision);
            }

            int oversidedBy = size - wantedPrecision;
            BigInteger saveDroppedDigitsBI = val & ((BigInteger.One << oversidedBy) - 1);
            int downby = (oversidedBy < 64) ? (oversidedBy >> 2) + 1 : (oversidedBy - 32);
            ulong saveDroppedDigits = (ulong)(saveDroppedDigitsBI >> downby);

            val >>= oversidedBy;

            if ((saveDroppedDigits == 0) && (val * val > x))
            {
                val--;
            }

            return val;
        }
    }
}