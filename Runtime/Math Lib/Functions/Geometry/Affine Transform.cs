using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the result of transforming the <see cref="MaxMath.AffineTransform"/> <paramref name="b"/> by the <see cref="MaxMath.AffineTransform"/> <paramref name="a"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AffineTransform mul(AffineTransform a, AffineTransform b) => Unity.Mathematics.math.mul(a, b);

        /// <summary>       Returns the result of transforming the <see cref="MaxMath.AffineTransform"/> <paramref name="b"/> by a <see cref="MaxMath.float3x3"/> matrix <paramref name="a"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AffineTransform mul(float3x3 a, AffineTransform b) => Unity.Mathematics.math.mul(a, b);

        /// <summary>Returns the result of transforming the <see cref="MaxMath.float3x3"/> <paramref name="b"/> by an <see cref="MaxMath.AffineTransform"/> <paramref name="a"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AffineTransform mul(AffineTransform a, float3x3 b) => Unity.Mathematics.math.mul(a, b);

        /// <summary>       Returns the result of transforming a <see cref="MaxMath.float4"/> homogeneous coordinate by an <see cref="MaxMath.AffineTransform"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(AffineTransform a, float4 pos) => Unity.Mathematics.math.mul(a, pos);

        /// <summary>       Returns the result of rotating a <see cref="MaxMath.float3"/> vector by an <see cref="MaxMath.AffineTransform"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rotate(AffineTransform a, float3 dir) => Unity.Mathematics.math.rotate(a, dir);

        /// <summary>       Returns the result of transforming a <see cref="MaxMath.float3"/> point by an <see cref="MaxMath.AffineTransform"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 transform(AffineTransform a, float3 pos) => Unity.Mathematics.math.transform(a, pos);

        /// <summary>       Returns the inverse of an <see cref="MaxMath.AffineTransform"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AffineTransform inverse(AffineTransform a) => Unity.Mathematics.math.inverse(a);

        /// <summary>       Decomposes the <see cref="MaxMath.AffineTransform"/> in translation, rotation and scale.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void decompose(AffineTransform a, out float3 translation, out quaternion rotation, out float3 scale)
        {
            translation = a.t;
            rotation = math.rotation(a.rs);
            float3x3 sm = mul(new float3x3(conjugate(rotation)), a.rs);
            scale = new float3(sm.c0.x, sm.c1.y, sm.c2.z);
        }
    }
}
