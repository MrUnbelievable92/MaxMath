namespace MaxMath
{
    internal struct fixedpoint
    {
        const uint INT_BITS = 4;
        const uint FRAC_BITS = 4;

        internal sbyte value;

        public static explicit operator sbyte(fixedpoint f)
        {
            return (sbyte)(f.value >> (int)FRAC_BITS);
        }

        public static explicit operator fixedpoint(sbyte s)
        {
            return new fixedpoint { value = (sbyte)(s << (int)FRAC_BITS) };
        }
    }
}
