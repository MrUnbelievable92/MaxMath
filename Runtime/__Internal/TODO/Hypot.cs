
//public static v128 hypot_ps(v128 a, v128 b)
//{
//    if (Constant.IsConstantExpression(a))
//    {
//        return Sse.sqrt_ps(fmadd_ps(b, b, Sse.mul_ps(a, a)));
//    }
//    else if (Constant.IsConstantExpression(b))
//    {
//        return Sse.sqrt_ps(fmadd_ps(a, a, Sse.mul_ps(b, b)));
//    }
//    else
//    {
//        return Sse.sqrt_ps(Sse.add_ps(Sse.mul_ps(a, a), Sse.mul_ps(b, b)));
//    }
//}
//
//
//
//
//
//public static v128 hypot_epi16(v128 a, v128 b, byte elements = 8)
//{
//    if (elements <= 4)
//    {
//        v128 interleaved = Sse2.unpacklo_epi16(a, b);
//        v128 radicands32 = Sse2.madd_epi16(interleaved, interleaved);
//
//        return sqrt_epi32(radicands32);
//    }
//    else 
//    {
//        if (Avx2.IsAvx2Supported)
//        {
//
//        }
//        else
//        {
//
//        }
//    }
//}