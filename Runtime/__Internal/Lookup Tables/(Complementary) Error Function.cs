namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class ERF_C
        {
            internal const double F64_TINY =  1e-300;
			internal const double F64_ERX  =  8.45062911510467529297e-01; 
			internal const double F64_EFX  =  1.28379167095512586316e-01; 
			internal const double F64_EFX8 =  1.02703333676410069053e+00; 
			internal const double F64_PP0  =  1.28379167095512558561e-01;
			internal const double F64_PP1  = -3.25042107247001499370e-01;
			internal const double F64_PP2  = -2.84817495755985104766e-02;
			internal const double F64_PP3  = -5.77027029648944159157e-03;
			internal const double F64_PP4  = -2.37630166566501626084e-05;
			internal const double F64_QQ1  =  3.97917223959155352819e-01;
			internal const double F64_QQ2  =  6.50222499887672944485e-02;
			internal const double F64_QQ3  =  5.08130628187576562776e-03;
			internal const double F64_QQ4  =  1.32494738004321644526e-04;
			internal const double F64_QQ5  = -3.96022827877536812320e-06;
			internal const double F64_PA0  = -2.36211856075265944077e-03;
			internal const double F64_PA1  =  4.14856118683748331666e-01;
			internal const double F64_PA2  = -3.72207876035701323847e-01;
			internal const double F64_PA3  =  3.18346619901161753674e-01;
			internal const double F64_PA4  = -1.10894694282396677476e-01;
			internal const double F64_PA5  =  3.54783043256182359371e-02;
			internal const double F64_PA6  = -2.16637559486879084300e-03;
			internal const double F64_QA1  =  1.06420880400844228286e-01;
			internal const double F64_QA2  =  5.40397917702171048937e-01;
			internal const double F64_QA3  =  7.18286544141962662868e-02;
			internal const double F64_QA4  =  1.26171219808761642112e-01;
			internal const double F64_QA5  =  1.36370839120290507362e-02;
			internal const double F64_QA6  =  1.19844998467991074170e-02;
			internal const double F64_RA0  = -9.86494403484714822705e-03;
			internal const double F64_RA1  = -6.93858572707181764372e-01;
			internal const double F64_RA2  = -1.05586262253232909814e+01;
			internal const double F64_RA3  = -6.23753324503260060396e+01;
			internal const double F64_RA4  = -1.62396669462573470355e+02;
			internal const double F64_RA5  = -1.84605092906711035994e+02;
			internal const double F64_RA6  = -8.12874355063065934246e+01;
			internal const double F64_RA7  = -9.81432934416914548592e+00;
			internal const double F64_SA1  =  1.96512716674392571292e+01;
			internal const double F64_SA2  =  1.37657754143519042600e+02;
			internal const double F64_SA3  =  4.34565877475229228821e+02;
			internal const double F64_SA4  =  6.45387271733267880336e+02;
			internal const double F64_SA5  =  4.29008140027567833386e+02;
			internal const double F64_SA6  =  1.08635005541779435134e+02;
			internal const double F64_SA7  =  6.57024977031928170135e+00;
			internal const double F64_SA8  = -6.04244152148580987438e-02;
			internal const double F64_RB0  = -9.86494292470009928597e-03;
			internal const double F64_RB1  = -7.99283237680523006574e-01;
			internal const double F64_RB2  = -1.77579549177547519889e+01;
			internal const double F64_RB3  = -1.60636384855821916062e+02;
			internal const double F64_RB4  = -6.37566443368389627722e+02;
			internal const double F64_RB5  = -1.02509513161107724954e+03;
			internal const double F64_RB6  = -4.83519191608651397019e+02;
			internal const double F64_SB1  =  3.03380607434824582924e+01;
			internal const double F64_SB2  =  3.25792512996573918826e+02;
			internal const double F64_SB3  =  1.53672958608443695994e+03;
			internal const double F64_SB4  =  3.19985821950859553908e+03;
			internal const double F64_SB5  =  2.55305040643316442583e+03;
			internal const double F64_SB6  =  4.74528541206955367215e+02;
			internal const double F64_SB7  = -2.24409524465858183362e+01;

			internal const float F32_TINY =  1e-120f;
			internal const float F32_ERX  =  8.4506291151e-01f;
			internal const float F32_EFX  =  1.0270333290e+00f;
			internal const float F32_PP0  =  1.2837916613e-01f;
			internal const float F32_PP1  = -3.2504209876e-01f;
			internal const float F32_PP2  = -2.8481749818e-02f;
			internal const float F32_PP3  = -5.7702702470e-03f;
			internal const float F32_PP4  = -2.3763017452e-05f;
			internal const float F32_QQ1  =  3.9791721106e-01f;
			internal const float F32_QQ2  =  6.5022252500e-02f;
			internal const float F32_QQ3  =  5.0813062117e-03f;
			internal const float F32_QQ4  =  1.3249473704e-04f;
			internal const float F32_QQ5  = -3.9602282413e-06f;
			internal const float F32_PA0  = -2.3621185683e-03f;
			internal const float F32_PA1  =  4.1485610604e-01f;
			internal const float F32_PA2  = -3.7220788002e-01f;
			internal const float F32_PA3  =  3.1834661961e-01f;
			internal const float F32_PA4  = -1.1089469492e-01f;
			internal const float F32_PA5  =  3.5478305072e-02f;
			internal const float F32_PA6  = -2.1663755178e-03f;
			internal const float F32_QA1  =  1.0642088205e-01f;
			internal const float F32_QA2  =  5.4039794207e-01f;
			internal const float F32_QA3  =  7.1828655899e-02f;
			internal const float F32_QA4  =  1.2617121637e-01f;
			internal const float F32_QA5  =  1.3637083583e-02f;
			internal const float F32_QA6  =  1.1984500103e-02f;
			internal const float F32_RA0  = -9.8649440333e-03f;
			internal const float F32_RA1  = -6.9385856390e-01f;
			internal const float F32_RA2  = -1.0558626175e+01f;
			internal const float F32_RA3  = -6.2375331879e+01f;
			internal const float F32_RA4  = -1.6239666748e+02f;
			internal const float F32_RA5  = -1.8460508728e+02f;
			internal const float F32_RA6  = -8.1287437439e+01f;
			internal const float F32_RA7  = -9.8143291473e+00f;
			internal const float F32_SA1  =  1.9651271820e+01f;
			internal const float F32_SA2  =  1.3765776062e+02f;
			internal const float F32_SA3  =  4.3456588745e+02f;
			internal const float F32_SA4  =  6.4538726807e+02f;
			internal const float F32_SA5  =  4.2900814819e+02f;
			internal const float F32_SA6  =  1.0863500214e+02f;
			internal const float F32_SA7  =  6.5702495575e+00f;
			internal const float F32_SA8  = -6.0424413532e-02f;
			internal const float F32_RB0  = -9.8649431020e-03f;
			internal const float F32_RB1  = -7.9928326607e-01f;
			internal const float F32_RB2  = -1.7757955551e+01f;
			internal const float F32_RB3  = -1.6063638306e+02f;
			internal const float F32_RB4  = -6.3756646729e+02f;
			internal const float F32_RB5  = -1.0250950928e+03f;
			internal const float F32_RB6  = -4.8351919556e+02f;
			internal const float F32_SB1  =  3.0338060379e+01f;
			internal const float F32_SB2  =  3.2579251099e+02f;
			internal const float F32_SB3  =  1.5367296143e+03f;
			internal const float F32_SB4  =  3.1998581543e+03f;
			internal const float F32_SB5  =  2.5530502930e+03f;
			internal const float F32_SB6  =  4.7452853394e+02f;
			internal const float F32_SB7  = -2.2440952301e+01f;
        }
    }
}