using System;

namespace MaxMath
{
    public class BurstCompilerException : Exception
    {
        public BurstCompilerException() 
            : base("Internal CPU feature check error - please submit a bug report with the full call stack at https://github.com/MrUnbelievable92/MaxMath/issues") 
        { 

        }
    }
}
