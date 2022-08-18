using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dsub(float a, float b, float c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 dsub(float2 a, float2 b, float2 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 dsub(float3 a, float3 b, float3 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="float4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 dsub(float4 a, float4 b, float4 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 dsub(float8 a, float8 b, float8 c, bool fast = false)
        {
            return mad(a, fast ? fastrcp(b) : rcp(b), -c);
        }

        
        /// <summary>       Returns the result of a divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double dsub(double a, double b, double c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 dsub(double2 a, double2 b, double2 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 dsub(double3 a, double3 b, double3 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }

        /// <summary>       Returns the result of a componentwise divide-subtract operation (<paramref name="a"/> <see langword="/" /> <paramref name="b"/> <see langword="-" /> <paramref name="c"/>) on 3 <see cref="double4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 dsub(double4 a, double4 b, double4 c, bool fast = false)
        {
            return math.mad(a, fast ? fastrcp(b) : math.rcp(b), -c);
        }
    }
}