using System;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        internal const Promise WELL_KNOWN_COMB_PROMISES = PROMISE_POSITIVE | PROMISE_NOT_ONE | PROMISE_LZCNT_NOT_0;
    }
}
