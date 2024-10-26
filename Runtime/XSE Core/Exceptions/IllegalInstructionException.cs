using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    public class IllegalInstructionException : Exception
    {
        private IllegalInstructionException() {  }

        public IllegalInstructionException([CallerMemberName] string func = null)
            : base($"Attempted to execute an illegal instruction at { func } - please submit a bug report with the full call stack if possible at https://github.com/MrUnbelievable92/MaxMath/issues")
        {

        }
    }
}