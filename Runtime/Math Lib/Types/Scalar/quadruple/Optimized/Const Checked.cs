using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public readonly partial struct quadruple
    {
        internal struct ConstChecked
        {
            internal quadruple Value;
            internal FloatingPointPromise<quadruple> Promise;


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ConstChecked(quadruple.ConstChecked f128, FloatingPointPromise<quadruple> promise)
            {
                Value = f128.Value;
                Promise = promise;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator quadruple(quadruple.ConstChecked promised) => promised.Value;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator quadruple.ConstChecked(quadruple f128) => new ConstChecked{ Value = f128, Promise = new FloatingPointPromise<quadruple>(f128) };
        }
    }
}
