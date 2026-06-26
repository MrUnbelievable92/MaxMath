using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Transforms the AABB with the given transform. The resulting AABB encapsulates the transformed AABB which may not be axis aligned after the transformation.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MinMaxAABB transform(RigidTransform transform, MinMaxAABB aabb) => Unity.Mathematics.Geometry.Math.Transform(transform, aabb);
        
        /// <summary>   Transforms the AABB with the given transform. The resulting AABB encapsulates the transformed AABB which may not be axis aligned after the transformation.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MinMaxAABB transform(float4x4 transform, MinMaxAABB aabb) => Unity.Mathematics.Geometry.Math.Transform(transform, aabb);
        
        /// <summary>   Transforms the AABB with the given transform. The resulting AABB encapsulates the transformed AABB which may not be axis aligned after the transformation.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MinMaxAABB transform(float3x3 transform, MinMaxAABB aabb) => Unity.Mathematics.Geometry.Math.Transform(transform, aabb);
    }
}
