using System.Runtime.CompilerServices;

namespace MaxMath
{
    public static partial class math
    {
        /// <summary>   Returns the inverse of a <see cref="MaxMath.RigidTransform"/>.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform inverse(RigidTransform t)
        {
            quaternion invRotation = inverse(t.rot);
            float3 invTranslation = mul(invRotation, -t.pos);
            return new RigidTransform(invRotation, invTranslation);
        }

        /// <summary>   Returns the result of transforming the <see cref="MaxMath.RigidTransform"/> <paramref name="b"/> by the <see cref="MaxMath.RigidTransform"/> <paramref name="a"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RigidTransform mul(RigidTransform a, RigidTransform b) => Unity.Mathematics.math.mul(a, b);

        /// <summary>   Returns the result of transforming a float4 homogeneous coordinate by a <see cref="MaxMath.RigidTransform"/>.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mul(RigidTransform a, float4 pos) => Unity.Mathematics.math.mul(a, pos);

        /// <summary>   Returns the result of rotating a <see cref="MaxMath.float3"/> vector by a <see cref="MaxMath.RigidTransform"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rotate(RigidTransform a, float3 dir) => Unity.Mathematics.math.rotate(a, dir);

        /// <summary>   Returns the result of transforming a <see cref="MaxMath.float3"/> point by a <see cref="MaxMath.RigidTransform"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 transform(RigidTransform a, float3 pos) => Unity.Mathematics.math.transform(a, pos);
    }
}
