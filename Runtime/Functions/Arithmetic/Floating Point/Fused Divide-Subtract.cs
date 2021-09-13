using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a fast approximate divide-subtract operation (<paramref name="dividend"/> * (1 / <paramref name="divisor"/>) - <paramref name="summand"/>) on 3 <see cref="float"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dsub(float dividend, float divisor, float summand, bool fast = false)
        {
            return math.mad(dividend, fast ? fastrcp(divisor) : math.rcp(divisor), -summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-subtract operation (<paramref name="dividend"/> * (1 / <paramref name="divisor"/>) - <paramref name="summand"/>) on 3 <see cref="float2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dsub(float2 dividend, float2 divisor, float2 summand, bool fast = false)
        {
            return math.mad(dividend, fast ? fastrcp(divisor) : math.rcp(divisor), -summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-subtract operation (<paramref name="dividend"/> * (1 / <paramref name="divisor"/>) - <paramref name="summand"/>) on 3 <see cref="float3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dsub(float3 dividend, float3 divisor, float3 summand, bool fast = false)
        {
            return math.mad(dividend, fast ? fastrcp(divisor) : math.rcp(divisor), -summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-subtract operation (<paramref name="dividend"/> * (1 / <paramref name="divisor"/>) - <paramref name="summand"/>) on 3 <see cref="float4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dsub(float4 dividend, float4 divisor, float4 summand, bool fast = false)
        {
            return math.mad(dividend, fast ? fastrcp(divisor) : math.rcp(divisor), -summand);
        }

        /// <summary>       Returns the result of a componentwise fast approximate divide-subtract operation (<paramref name="dividend"/> * (1 / <paramref name="divisor"/>) - <paramref name="summand"/>) on 3 <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dsub(float8 dividend, float8 divisor, float8 summand, bool fast = false)
        {
            return mad(dividend, fast ? fastrcp(divisor) : rcp(divisor), -summand);
        }
    }
}