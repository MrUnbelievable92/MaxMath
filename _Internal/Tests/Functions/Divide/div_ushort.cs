using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    /// Float/Double implicitly tested by testing Int/Long
    unsafe public static class div_ushort
    {
        [UnitTest("Functions", "Arithmetic", "Div", "UShort")]
        public static bool _3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 3;

                result &= x.x0 == Tests.UShort8.TestData_LHS[i].x0 / 3;
                result &= x.x1 == Tests.UShort8.TestData_LHS[i].x1 / 3;
                result &= x.x2 == Tests.UShort8.TestData_LHS[i].x2 / 3;
                result &= x.x3 == Tests.UShort8.TestData_LHS[i].x3 / 3;
                result &= x.x4 == Tests.UShort8.TestData_LHS[i].x4 / 3;
                result &= x.x5 == Tests.UShort8.TestData_LHS[i].x5 / 3;
                result &= x.x6 == Tests.UShort8.TestData_LHS[i].x6 / 3;
                result &= x.x7 == Tests.UShort8.TestData_LHS[i].x7 / 3;
            }

            return result;
        }
    }
#endif
}