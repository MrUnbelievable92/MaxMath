using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    /// <summary>   Axis aligned bounding box (AABB) stored in min and max form.    </summary>
    [Serializable]
    public struct MinMaxAABB : IEquatable<MinMaxAABB>, IEquatable<Unity.Mathematics.Geometry.MinMaxAABB>
    {
        /// <summary>   The minimum point contained by the AABB.    </summary>
        public float3 Min;

        /// <summary>   The maximum point contained by the AABB.    </summary>
        public float3 Max;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MinMaxAABB(float3 min, float3 max)
        {
            Min = min;
            Max = max;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator MinMaxAABB(Unity.Mathematics.Geometry.MinMaxAABB input) => new MinMaxAABB { Min = input.Min, Max = input.Max };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.Geometry.MinMaxAABB(MinMaxAABB input) => new Unity.Mathematics.Geometry.MinMaxAABB { Min = input.Min, Max = input.Max };


        /// <summary>   Creates the AABB from a center and extents.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MinMaxAABB CreateFromCenterAndExtents(float3 center, float3 extents)
        {
            return CreateFromCenterAndHalfExtents(center, extents * 0.5f);
        }

        /// <summary>   Creates the AABB from a center and half extents.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MinMaxAABB CreateFromCenterAndHalfExtents(float3 center, float3 halfExtents)
        {
            return new MinMaxAABB(center - halfExtents, center + halfExtents);
        }

        /// <summary>   Computes the extents of the AABB.   </summary>
        public readonly float3 Extents => Max - Min;

        /// <summary>   Computes the half extents of the AABB.  </summary>
        public readonly float3 HalfExtents => (Max - Min) * 0.5f;

        /// <summary>   Computes the center of the AABB.    </summary>
        public readonly float3 Center => (Max + Min) * 0.5f;

        /// <summary>   Check if the AABB is valid.     </summary>
        public readonly bool IsValid => math.all(Min <= Max);

        /// <summary>   Computes the surface area for this axis aligned bounding box.   </summary>
        public readonly float SurfaceArea
        {
            get
            {
                float3 diff = Max - Min;
                return 2 * math.dot(diff, diff.yzx);
            }
        }

        /// <summary>   Tests if the input point is contained by the AABB.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Contains(float3 point) => math.all(point >= Min & point <= Max);

        /// <summary>   Tests if the input AABB is contained entirely by this AABB.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Contains(MinMaxAABB aabb) => math.all((Min <= aabb.Min) & (Max >= aabb.Max));

        /// <summary>   Tests if the input AABB overlaps this AABB.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Overlaps(MinMaxAABB aabb) => math.all(Max >= aabb.Min & Min <= aabb.Max);

        /// <summary>   Expands the AABB by the given signed distance.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Expand(float signedDistance)
        {
            Min -= signedDistance;
            Max += signedDistance;
        }

        /// <summary>   Modifies this AABB so that it contains the given AABB. If the given AABB is already contained by this AABB, then this AABB doesn't change.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(MinMaxAABB aabb)
        {
            Min = math.min(Min, aabb.Min);
            Max = math.max(Max, aabb.Max);
        }

        /// <summary>   Modifies this AABB so that it contains the given point. If the given point is already contained by this AABB, then this AABB doesn't change.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Encapsulate(float3 point)
        {
            Min = math.min(Min, point);
            Max = math.max(Max, point);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(MinMaxAABB other) => math.all(this.Min == other.Min & this.Max == other.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.Geometry.MinMaxAABB other) => this.Equals((MinMaxAABB)other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.Geometry.MinMaxAABB)this).ToString();

    }
}
