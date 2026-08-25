using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

using static MaxMath.math;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        /// <summary>
        /// Branch free abnormal value selection base that runs in SIMD registers
        /// in parallel to the hot path, GPR heavy calculations for quadruple operations.
        /// Additionally, in operator chains, the constant vectors and classification results
        /// remain in the vector registers for efficient re-use
        /// </summary>
        internal ref struct Classification
        {
            private quadruple Value;
            internal mask64x4 Mask;
            internal readonly bool Zero => Mask.x;
            internal readonly bool Inf => Mask.y;
            internal readonly bool NaN => Mask.z;
            internal readonly bool Sign => Mask.w;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal Classification(quadruple value)
            {
                Value = value;
                Mask = default;
                Classify();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal void Classify()
            {
                ulong4 cvt = Value.value.hi64;
                cvt.w = Value.value.lo64;

                ulong4 cmpAND = new ulong4(SIGNALING_EXPONENT.hi64, 1ul << 63, bitmask64((ulong)MANTISSA_BITS_HI64), ulong.MaxValue);
                ulong4 cmpEQ1 = new ulong4(SIGNALING_EXPONENT.hi64, 1ul << 63, 0,                                    0             );

                mask64x4 cmpeq1 = (cvt & cmpAND) == cmpEQ1;
                mask64x4 cmpeq2 = (cvt & cmpAND) == 0;

                mask64x4 align1 = cmpeq1.zxxy;
                mask64x4 align2 = select(cmpeq1.zzzy, cmpeq2, new bool4(true, false, false, false));
                mask64x4 align3 = cmpeq1.wwwy;

                align2 &= align3;

                //1 cycle faster to blend but off the critical path and code size matters more

                //const byte mask = 0b0010;
                //for (int align1 = 0; align1 < 16; align1++)
                //{
                //    for (int align2 = 0; align2 < 16; align2++)
                //    {
                //        int result0 = 0xF & bits_select(align1 & align2, align1 & ~align2, mask);
                //        int result1 = 0xF & (align1 & (align2 ^ mask));
                //
                //        DevTools.Assert.AreEqual(result0, result1);
                //    }
                //}

                Mask = align1 & (align2 ^ new mask64x4(false, false, true, false));
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void Consider(ref ulong2 abnormalResult, ref mask64x2 returnAbnormalResult, mask64x2 condition, ulong2 candidate)
            {
                abnormalResult = select(abnormalResult, candidate, condition);
                returnAbnormalResult |= condition;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static quadruple.ConstChecked AbnormalAdd(quadruple.ConstChecked left, quadruple.ConstChecked right, quadruple.ConstChecked computed)
            {
                ulong2 abnormalResult = default;
                mask64x2 returnAbnormal = false;

                Classification leftClassification = new Classification(left);
                Classification rightClassification = new Classification(right);

                mask64x4 aANDb = leftClassification.Mask & rightClassification.Mask;
                mask64x4 aORb = leftClassification.Mask | rightClassification.Mask;
                mask64x4 aANDNOTb = andnot(leftClassification.Mask, rightClassification.Mask);
                mask64x4 bANDNOTa = andnot(rightClassification.Mask, leftClassification.Mask);
                mask64x4 bCMPEQa = leftClassification.Mask == rightClassification.Mask;

                mask64x2 bothZero    = left.Promise.NonZero && right.Promise.NonZero ? false : aANDb.xx;
                mask64x2 sameSign    = (left.Promise.Positive && right.Promise.Positive) || (left.Promise.Negative && right.Promise.Negative) ? true : bCMPEQa.ww;
                mask64x2 bothInfSame = left.Promise.NotInf && right.Promise.NotInf ? false : aANDb.yy & bCMPEQa.ww;
                mask64x2 bothInfOpp  = left.Promise.NotInf && right.Promise.NotInf ? false : andnot(aANDb.yy, bCMPEQa.ww);
                mask64x2 onlyAInf    = left.Promise.NotInf ? false : aANDNOTb.yy;
                mask64x2 onlyBInf    = right.Promise.NotInf ? false : bANDNOTa.yy;
                mask64x2 anyNaN      = left.Promise.NotNaN && right.Promise.NotNaN ? false : aORb.zz;
                
                sameSign.x = false;
                ulong2 signedZero = select(0, toulong(leftClassification.Mask.ww) << 63, sameSign);
                ulong2 signedInfA = bits_select(new ulong2(PositiveInfinity.value.lo64, PositiveInfinity.value.hi64), new ulong2(left.Value.value.lo64, left.Value.value.hi64), toulong(leftClassification.Mask.ww) << 63);

                Consider(ref abnormalResult, ref returnAbnormal, bothZero,             signedZero);
                Consider(ref abnormalResult, ref returnAbnormal, bothInfSame,          signedInfA);
                Consider(ref abnormalResult, ref returnAbnormal, onlyAInf,             new ulong2(left.Value.value.lo64, left.Value.value.hi64));
                Consider(ref abnormalResult, ref returnAbnormal, onlyBInf,             new ulong2(right.Value.value.lo64, right.Value.value.hi64));
                Consider(ref abnormalResult, ref returnAbnormal, bothInfOpp | anyNaN,  new ulong2(quadruple.NaN.value.lo64, quadruple.NaN.value.hi64));

                return returnAbnormal.x ? new quadruple(abnormalResult.x, abnormalResult.y) : computed;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static quadruple.ConstChecked AbnormalMul(quadruple.ConstChecked left, quadruple.ConstChecked right, quadruple.ConstChecked computed)
            {
                ulong2 abnormalResult = default;
                mask64x2 returnAbnormal = false;

                Classification leftClassification = new Classification(left);
                Classification rightClassification = new Classification(right);

                mask64x4 aANDb = leftClassification.Mask & rightClassification.Mask;
                mask64x4 aORb  = leftClassification.Mask | rightClassification.Mask;

                mask64x2 zeroCase = andnot(aORb.xx, aORb.yy);
                mask64x2 infCase  = andnot(aORb.yy, aORb.xx);
                mask64x2 invalid  = (leftClassification.Mask.xx & rightClassification.Mask.yy) | (rightClassification.Mask.xx & leftClassification.Mask.yy);
                mask64x2 anyNaN   = aORb.zz;

                Consider(ref abnormalResult, ref returnAbnormal, zeroCase,          select(0, 1ul << 63, leftClassification.Mask.ww ^ rightClassification.Mask.ww));
                Consider(ref abnormalResult, ref returnAbnormal, infCase,           select(quadruple.PositiveInfinity.Reinterpret<quadruple, ulong2>(), quadruple.NegativeInfinity.Reinterpret<quadruple, ulong2>(), leftClassification.Mask.ww ^ rightClassification.Mask.ww));
                Consider(ref abnormalResult, ref returnAbnormal, invalid | anyNaN,  quadruple.NaN.Reinterpret<quadruple, ulong2>());
                
                return select(computed.Value.Reinterpret<quadruple, ulong2>(), abnormalResult, returnAbnormal).Reinterpret<ulong2, quadruple>();
            }
            


//const ulong SignMask   = 0x8000_0000_0000_0000UL;
//const ulong ExpMask    = 0x7FFF_0000_0000_0000UL;
//const ulong FracHiMask = 0x0000_FFFF_FFFF_FFFFUL;
//
//static ulong ZeroHi(bool sign) => sign ? SignMask : 0UL;
//static ulong InfHi(bool sign)  => (sign ? SignMask : 0UL) | ExpMask;
//
//quadruple Sub(quadruple a, quadruple b) => Add(a, Negate(b));
//
//quadruple Mul(quadruple a, quadruple b)
//{
//    var (aZero, aInf, aNaN, aSign) = Classify(a);
//    var (bZero, bInf, bNaN, bSign) = Classify(b);
//    bool sign = aSign ^ bSign;
//
//    quadruple normalResult = MulNormalPath(a, b);
//
//    quadruple abnormalResult = default;
//    bool returnAbnormal = false;
//
//    bool zeroCase    = (aZero || bZero) && !aInf && !bInf;
//    bool infCase       = (aInf || bInf) && !aZero && !bZero;
//    bool invalid        = (aZero && bInf) || (aInf && bZero);
//    bool anyNaN          = aNaN || bNaN;
//
//    Consider(ref abnormalResult, ref returnAbnormal, zeroCase, ZeroHi(sign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, infCase,  InfHi(sign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, invalid,  NaN);
//
//    return new quadruple { Hi = returnAbnormal ? abnormalResult.Hi : normalResult.Hi,
//                           Lo = returnAbnormal ? abnormalResult.Lo : normalResult.Lo };
//}
//quadruple Div(quadruple a, quadruple b)
//{
//    var (aZero, aInf, aNaN, aSign) = Classify(a);
//    var (bZero, bInf, bNaN, bSign) = Classify(b);
//    bool sign = aSign ^ bSign;
//
//    quadruple normalResult = DivNormalPath(a, b);
//
//    quadruple abnormalResult = default;
//    bool returnAbnormal = false;
//
//    bool zeroResult = (aZero && !bZero) || (bInf && !aZero);
//    bool infResult    = (aInf && !bInf) || (bZero && !aInf);
//    bool invalid       = (aZero && bZero) || (aInf && bInf);
//    bool anyNaN         = aNaN || bNaN;
//
//    Consider(ref abnormalResult, ref returnAbnormal, zeroResult, ZeroHi(sign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, infResult,  InfHi(sign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, invalid,    NaN);
//
//    return new quadruple { Hi = returnAbnormal ? abnormalResult.Hi : normalResult.Hi,
//                           Lo = returnAbnormal ? abnormalResult.Lo : normalResult.Lo };
//}
//quadruple Fmod(quadruple x, quadruple y)
//{
//    var (xZero, xInf, xNaN, xSign) = Classify(x);
//    var (yZero, yInf, yNaN, ySign) = Classify(y);
//
//    quadruple normalResult = FmodNormalPath(x, y);
//
//    quadruple abnormalResult = default;
//    bool returnAbnormal = false;
//
//    bool xZeroCase = xZero && !yZero;
//    bool yInfCase   = yInf && !xInf; 
//    bool invalid     = xInf || yZero;
//    bool anyNaN       = xNaN || yNaN;
//
//    Consider(ref abnormalResult, ref returnAbnormal, xZeroCase, x.Hi, x.Lo);
//    Consider(ref abnormalResult, ref returnAbnormal, yInfCase,  x.Hi, x.Lo);
//    Consider(ref abnormalResult, ref returnAbnormal, invalid,   NaN);
//
//    return new quadruple { Hi = returnAbnormal ? abnormalResult.Hi : normalResult.Hi,
//                           Lo = returnAbnormal ? abnormalResult.Lo : normalResult.Lo };
//}
//quadruple Sqrt(quadruple x)
//{
//    var (xZero, xInf, xNaN, xSign) = Classify(x);
//
//    quadruple normalResult = SqrtNormalPath(x);
//
//    quadruple abnormalResult = default;
//    bool returnAbnormal = false;
//
//    bool zeroCase   = xZero;             
//    bool infCase      = xInf && !xSign;  
//    bool negInvalid    = xSign && !xZero;
//
//    Consider(ref abnormalResult, ref returnAbnormal, zeroCase, x.Hi, x.Lo); 
//    Consider(ref abnormalResult, ref returnAbnormal, infCase,  x.Hi, x.Lo); 
//    Consider(ref abnormalResult, ref returnAbnormal, negInvalid, NaN);
//
//    return new quadruple { Hi = returnAbnormal ? abnormalResult.Hi : normalResult.Hi,
//                           Lo = returnAbnormal ? abnormalResult.Lo : normalResult.Lo };
//}
//quadruple Fma   (quadruple x, quadruple y, quadruple z) => FmaCore(x,        y, z);
//quadruple Fmsub (quadruple x, quadruple y, quadruple z) => FmaCore(x,        y, Negate(z));
//quadruple Fnmadd(quadruple x, quadruple y, quadruple z) => FmaCore(Negate(x), y, z);
//quadruple Fnmsub(quadruple x, quadruple y, quadruple z) => FmaCore(Negate(x), y, Negate(z));
//quadruple FmaCore(quadruple x, quadruple y, quadruple z)
//{
//    var (xZero, xInf, xNaN, xSign) = Classify(x);
//    var (yZero, yInf, yNaN, ySign) = Classify(y);
//    var (zZero, zInf, zNaN, zSign) = Classify(z);
//
//    quadruple normalResult = FmaNormalPath(x, y, z);
//
//    quadruple abnormalResult = default;
//    bool returnAbnormal = false;
//
//    bool prodSign     = xSign ^ ySign;
//    bool prodZero      = (xZero || yZero) && !xInf && !yInf;
//    bool prodInf         = (xInf || yInf) && !xZero && !yZero;
//    bool prodInvalid      = (xZero && yInf) || (xInf && yZero);   // 0 * Inf
//
//    bool sameSign        = prodSign == zSign;
//    bool rdMode            = RoundingMode == RoundingMode.TowardNegative;
//    ulong zeroSignBit       = sameSign ? (prodSign ? 1UL : 0UL) : (rdMode ? 1UL : 0UL);
//
//    bool bothZero            = prodZero && zZero;
//    bool bothInfSame           = prodInf && zInf && sameSign;
//    bool bothInfOpp              = prodInf && zInf && !sameSign;
//    bool onlyProdInf              = prodInf && !zInf;
//    bool onlyZInf                   = zInf && !prodInf;
//    bool invalid                     = prodInvalid || bothInfOpp;
//    bool anyNaN                       = xNaN || yNaN || zNaN;
//
//    Consider(ref abnormalResult, ref returnAbnormal, bothZero,     ZeroHi(zeroSignBit != 0), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, bothInfSame,   InfHi(prodSign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, onlyProdInf,   InfHi(prodSign), 0);
//    Consider(ref abnormalResult, ref returnAbnormal, onlyZInf,      z.Hi, z.Lo);   // passthrough
//    Consider(ref abnormalResult, ref returnAbnormal, invalid,       NaN);
//
//    return new quadruple { Hi = returnAbnormal ? abnormalResult.Hi : normalResult.Hi,
//                           Lo = returnAbnormal ? abnormalResult.Lo : normalResult.Lo };
//}
        }
    }
}
