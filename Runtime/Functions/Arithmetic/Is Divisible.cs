namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       <para>     Returns true if the unsigned dividend is evenly divisible by the unsigned divisor.       </para> 
        /// USE WITH COMPILE-TIME CONSTANTS ONLY! https://lemire.me/blog/2019/02/08/faster-remainders-when-the-divisor-is-a-constant-beating-compilers-and-libdivide/     </summary>
        public static bool isdivisible(uint dividend, uint divisor)
        {
            ulong compile = (ulong.MaxValue / divisor) + 1;

            return dividend * compile <= compile - 1;
        }
    }
}