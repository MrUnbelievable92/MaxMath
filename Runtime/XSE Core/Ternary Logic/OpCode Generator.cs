using System;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        /// <summary>
        ///     Generates an opcode for <see cref="ternarylogic_si128"/> and <see cref="mm256_ternarylogic_si256"/> given any possible three valued boolean expression, 
        ///     where the parameter order of '<paramref name="ternaryBooleanExpression"/>' maps to the parameter order of the mentioned intrinsics, 
        ///     i.e. "<paramref name="ternaryBooleanExpression"/> = (a, b, c) =&gt; a ^ (b ? c : !a)" is equivalent to "(a ^ c) | !b" and maps to ternarylogic_si128(a, b, c, 0x7B).
        /// </summary>
        /// <remarks>
        ///     <see cref="Func{bool, bool, bool, bool}"/> is a managed type and cannot be used in Burst compiled code, even if the value could be calulated at compile time.
        ///     This is a tool intended for logging the opcode to the console.
        /// </remarks>
        public static byte __ternlog_opcode__(Func<bool, bool, bool, bool> ternaryBooleanExpression)
        {
            int result = 0;
            
            for (int i = 0; i < 8; i++)
            {
                int a = (i & 0b100) >> 2;
                int b = (i & 0b010) >> 1;
                int c = (i & 0b001) >> 0;
        
                bool truthValue = ternaryBooleanExpression(*(bool*)&a, *(bool*)&b, *(bool*)&c);
                result |= *(byte*)&truthValue << i;
            }
        
            return (byte)result;
        }
    }
}
