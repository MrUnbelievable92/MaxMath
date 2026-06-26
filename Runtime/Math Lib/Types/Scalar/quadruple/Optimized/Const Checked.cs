using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        internal struct ConstChecked
        {
            internal quadruple Value;
            internal FloatingPointPromise<quadruple> Promise;


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ConstChecked(MaxMath.quadruple.ConstChecked f128, FloatingPointPromise<quadruple> promise)
            {
                Value = f128.Value;
                Promise = promise;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator quadruple(MaxMath.quadruple.ConstChecked promised) => promised.Value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator MaxMath.quadruple.ConstChecked(quadruple f128) => new ConstChecked{ Value = f128, Promise = new FloatingPointPromise<quadruple>(f128) };
        }
    }
}
