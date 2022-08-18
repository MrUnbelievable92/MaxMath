using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    public class IllegalInstructionException : Exception
    {
        private IllegalInstructionException() {  }

        internal IllegalInstructionException([CallerMemberName] string func = null) 
            : base($"Internal CPU instruction set extension check error at { func } - please submit a bug report with the full call stack if possible at https://github.com/MrUnbelievable92/MaxMath/issues") 
        { 

        }
    }
}