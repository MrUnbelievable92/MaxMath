using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public partial struct quadruple
    {
        internal partial struct ConstChecked
        {
            internal quadruple Value;
            internal FloatingPointPromise<quadruple> Promise;


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ConstChecked(quadruple.ConstChecked f128, FloatingPointPromise<quadruple> promise)
            {
                Value = f128.Value;
                Promise = promise;
            }
            

        #if DEBUG
            public override bool Equals(object obj)
            {
                throw new System.NotImplementedException("Make the compiler shut up");
            }

            public override int GetHashCode()
            {
                throw new System.NotImplementedException("Make the compiler shut up");
            }
        #endif
        }
    }
}
