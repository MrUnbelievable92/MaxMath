namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class R_CBRT
        {
            internal const uint F32_DIVC = 0x548C_2B4B;
            internal const uint F32_DIVD = 0x2651_19F2;

            internal const float F32_C0 = 1.752319676f;
            internal const float F32_C1 = 1.2509524245f;
            internal const float F32_C2 = 0.5093818292f;

            internal const uint F64_DIVC = 0x2A9F_7893;
            internal const uint F64_DIVD = 0x297F_7893;

            internal const double F64_C0 =  1.87595182427177009643d;
            internal const double F64_C1 = -1.88497979543377169875d;
            internal const double F64_C2 =  1.621429720105354466140d;
            internal const double F64_C3 = -0.758397934778766047437d;
            internal const double F64_C4 =  0.145996192886612446982d;

            internal static quadruple F128_C0 => new quadruple(0xCA72_BE37_FFAE_AA72, 0x3FFC_1635_B766_3C13);
            internal static quadruple F128_C1 => new quadruple(0x2DF3_C159_2715_C82E, 0x3FFE_479C_EEA0_ACAB);
            internal static quadruple F128_C2 => new quadruple(0xDADC_FE83_11BD_2F9C, 0x3FFF_499D_3726_329D);
            internal static quadruple F128_C3 => new quadruple(0x3563_A320_B960_4A6A, 0x3FFF_7D5D_8695_2A9B);
            internal static quadruple F128_C4 => new quadruple(0x37E3_B0CC_FF40_0495, 0x3FFF_549B_64DA_5298);
            internal static quadruple F128_C5 => new quadruple(0xC4D2_9A82_FB8A_7601, 0x3FFD_80B2_FE7C_93D6);
        }
    }
}
