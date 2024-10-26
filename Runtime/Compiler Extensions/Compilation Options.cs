//#define TESTING

using Unity.Burst;

namespace MaxMath
{
    internal static class COMPILATION_OPTIONS
    {
        internal static OptimizeFor OPTIMIZE_FOR
        {   
            get;                           
        #if TESTING                         
            set; 
        #endif                                
        } = OptimizeFor.Performance; 

        internal static FloatMode FLOAT_MODE
        {   
            get;                           
        #if TESTING                         
            set; 
        #endif                                    
        } = FloatMode.Default; 

        internal static FloatPrecision FLOAT_PRECISION
        {   
            get;                           
        #if TESTING                         
            set; 
        #endif                               
        } = FloatPrecision.Standard; 


        internal static bool FLOAT_SIGNED_ZERO => FLOAT_MODE != FloatMode.Fast;
        internal static bool FLOAT_NO_NAN => FLOAT_MODE == FloatMode.Fast;
        internal static bool FLOAT_NO_INF => FLOAT_MODE == FloatMode.Fast;
        internal static bool FLOAT_DENORMALS_ARE_ZERO => FLOAT_PRECISION == FloatPrecision.Low;
    }
}
