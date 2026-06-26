using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the conjugate of a <see cref="MaxMath.quaternion"/> value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion conjugate(quaternion q)
        {
            return new quaternion(asfloat(asuint(q.value) ^ new uint4(1u << 31, 1u << 31, 1u << 31, 0)));
        }

        /// <summary>       Returns the inverse of a <see cref="MaxMath.quaternion"/> value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion inverse(quaternion q)
        {
            return conjugate(new quaternion(q.value / lengthsq(q)));
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.quaternion"/>s.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(quaternion a, quaternion b) => Unity.Mathematics.math.dot(a, b);

        /// <summary>       Returns the length of a <see cref="MaxMath.quaternion"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float length(quaternion q) => Unity.Mathematics.math.length(q);

        /// <summary>       Returns the squared length of a <see cref="MaxMath.quaternion"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lengthsq(quaternion q) => Unity.Mathematics.math.lengthsq(q);

        /// <summary>       Returns a normalized version of a <see cref="MaxMath.quaternion"/> q by scaling it by 1 <see langword="/"/> length(<paramref name="q"/>).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion normalize(quaternion q) => Unity.Mathematics.math.normalize(q);

        /// <summary>   Returns a safe normalized version of q by scaling it by 1 <see langword="/"/> length(<paramref name="q"/>). Returns the identity when 1 <see langword="/"/> length(<paramref name="q"/>) does not produce a finite number.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion normalizesafe(quaternion q) => Unity.Mathematics.math.normalizesafe(q);

        /// <summary>   Returns a safe normalized version of the q by scaling it by 1 <see langword="/"/> length(<paramref name="q"/>). Returns the given default value when 1 <see langword="/"/> length(<paramref name="q"/>) does not produce a finite number.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion normalizesafe(quaternion q, quaternion defaultvalue) => Unity.Mathematics.math.normalizesafe(q, defaultvalue);

        /// <summary>       Returns the natural exponent of a <see cref="MaxMath.quaternion"/>. Assumes w is zero.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion unitexp(quaternion q)
        {
            float v_len_sq = dot(q.value.xyz, q.value.xyz);
            sincos(sqrt(v_len_sq), out float sin_v_len, out float cos_v_len);
            return new quaternion(new float4(q.value.xyz * rsqrt(v_len_sq) * sin_v_len, cos_v_len));
        }

        /// <summary>       Returns the natural exponent of a <see cref="MaxMath.quaternion"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion exp(quaternion q)
        {
            return unitexp(q).value * exp(q.value.w);
        }

        /// <summary>       Returns the natural logarithm of a unit length <see cref="MaxMath.quaternion"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion unitlog(quaternion q) => Unity.Mathematics.math.unitlog(q);

        /// <summary>       Returns the natural logarithm of a <see cref="MaxMath.quaternion"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion log(quaternion q) => Unity.Mathematics.math.log(q);

        /// <summary>       Returns the result of transforming the <see cref="MaxMath.quaternion"/> <paramref name="b"/> by the <see cref="MaxMath.quaternion"/> <paramref name="a"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion mul(quaternion a, quaternion b) => Unity.Mathematics.math.mul(a, b);

        /// <summary>       Returns the result of transforming a vector by a <see cref="MaxMath.quaternion"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mul(quaternion q, float3 v) => Unity.Mathematics.math.mul(q, v);

        /// <summary>       Returns the result of rotating a vector by a unit <see cref="MaxMath.quaternion"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rotate(quaternion q, float3 v) => Unity.Mathematics.math.rotate(q, v);

        /// <summary>       Returns the result of a normalized linear interpolation between two <see cref="MaxMath.quaternion"/>s <paramref name="q1"/> and <paramref name="q2"/> using an interpolation parameter <paramref name="t"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion nlerp(quaternion q1, quaternion q2, float t) => Unity.Mathematics.math.nlerp(q1, q2, t);

        /// <summary>       Returns the result of a spherical interpolation between two <see cref="MaxMath.quaternion"/>s <paramref name="q1"/> and <paramref name="q2"/> using an interpolation parameter <paramref name="t"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion slerp(quaternion q1, quaternion q2, float t) => Unity.Mathematics.math.slerp(q1, q2, t);

        /// <summary>       Returns the angle in radians between two unit <see cref="MaxMath.quaternion"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(quaternion q1, quaternion q2) => Unity.Mathematics.math.angle(q1, q2);

        /// <summary>       Extracts the rotation from a <see cref="MaxMath.float3x3"/> matrix.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion rotation(float3x3 m) => Unity.Mathematics.math.rotation(m);

        /// <summary>    Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the XYZ rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerXYZ(quaternion q) => Unity.Mathematics.math.EulerXYZ(q);

        /// <summary>   Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the XZY rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerXZY(quaternion q) => Unity.Mathematics.math.EulerXZY(q);

        /// <summary>   Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the YXZ rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerYXZ(quaternion q) => Unity.Mathematics.math.EulerYXZ(q);

        /// <summary>   Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the YZX rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerYZX(quaternion q) => Unity.Mathematics.math.EulerYZX(q);

        /// <summary>   Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the ZXY rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerZXY(quaternion q) => Unity.Mathematics.math.EulerZXY(q);

        /// <summary>   Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/> following the ZYX rotation order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 EulerZYX(quaternion q) => Unity.Mathematics.math.EulerZYX(q);

        /// <summary>
        /// Returns the Euler angle representation of the <see cref="MaxMath.quaternion"/>. The returned angles depend on the specified order to apply the
        /// three rotations around the principal axes. All rotation angles are in radians and clockwise when looking along the
        /// rotation axis towards the origin.
        /// When the rotation order is known at compile time, to get the best performance you should use the specific
        /// Euler rotation constructors such as EulerZXY(...).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 Euler(quaternion q, math.RotationOrder order = math.RotationOrder.Default) => Unity.Mathematics.math.Euler(q, (Unity.Mathematics.math.RotationOrder)order);
    }
}
