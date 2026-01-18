//#define TESTING

using Unity.Burst;

namespace MaxMath
{
    public static class COMPILATION_OPTIONS
    {
        public static OptimizeFor OPTIMIZE_FOR
        {
            get;
        #if TESTING
            set;
        #endif
        } = OptimizeFor.Performance;

        public static FloatMode FLOAT_MODE
        {
            get;
        #if TESTING
            set;
        #endif
        } = FloatMode.Default;

        public static FloatPrecision FLOAT_PRECISION
        {
            get;
        #if TESTING
            set;
        #endif
        } = FloatPrecision.Standard;


        public static bool FLOAT_SIGNED_ZERO => FLOAT_MODE != FloatMode.Fast;
        public static bool FLOAT_NO_NAN => FLOAT_MODE == FloatMode.Fast;
        public static bool FLOAT_NO_INF => FLOAT_MODE == FloatMode.Fast;
        public static bool FLOAT_DENORMALS_ARE_ZERO => FLOAT_PRECISION == FloatPrecision.Low;
    }
}
