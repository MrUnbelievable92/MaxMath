using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(quarter q, Promise promise = Promise.Nothing)
        {
            return quadruple.FromQuarter(q, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(half h, Promise promise = Promise.Nothing)
        {
            return quadruple.FromHalf(h, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(float f, Promise promise = Promise.Nothing)
        {
            return quadruple.FromFloat(f, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="quadruple"/> representation.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for input values outside the interval [-1.18973149535723176508575932662800701619646905264e+4932, 1.797693134862315708145274237317043567981e+4932].       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values, including negative 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple toquadrupleunsafe(double d, Promise promise = Promise.Nothing)
        {
            return quadruple.FromDouble(d, promiseInRange: promise.Promises(Promise.NoOverflow), promiseAbs: promise.Promises(Promise.ZeroOrGreater));
        }
    }
}
