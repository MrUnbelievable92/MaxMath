namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class R_CBRT
        {
            internal const uint F32_DIV = 0x548C_2B4B;
            
            internal const float F32_C0 = 1.752319676f; 
            internal const float F32_C1 = 1.2509524245f; 
            internal const float F32_C2 = 0.5093818292f;

            internal const uint F64_DIV2 = 715_094_163;
            internal const uint F64_DIV1 = 696_219_795;
            
            internal const double F64_C0 =  1.87595182427177009643d; 
            internal const double F64_C1 = -1.88497979543377169875d; 
            internal const double F64_C2 =  1.621429720105354466140d;
            internal const double F64_C3 = -0.758397934778766047437d;
            internal const double F64_C4 =  0.145996192886612446982d;
        }
    }
}
