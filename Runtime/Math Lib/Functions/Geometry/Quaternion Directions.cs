using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    // A little more optimized and accurate (3 fmad ops) than the standard math.mul(q, new float3({-1, 0, 1}, {-1, 0, 1}, {-1, 0, 1}) calculation
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a <see cref="float3"/> representing the world space left direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 left(this quaternion rotation)
        {
            float4 temp = new float4(0f, -2f, 2f, 0f) * rotation.value.wzyx;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(-1f, 0f, 0f, 0f))).xyz;
        }

        /// <summary>       Returns a <see cref="float3"/> representing the world space right direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 right(this quaternion rotation)
        {
            float4 temp = new float4(0f, 2f, -2f, 0f) * rotation.value.wzyx;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(1f, 0f, 0f, 0f))).xyz;
        }

        /// <summary>       Returns a <see cref="float3"/> representing the world space up direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 up(this quaternion rotation)
        {
            float4 temp = new float4(-2f, 0f, 2f, 0f) * rotation.value.zyxw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 1f, 0f, 0f))).xyz;
        }

        /// <summary>       Returns a <see cref="float3"/> representing the world space down direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 down(this quaternion rotation)
        {
            float4 temp = new float4(2f, 0f, -2f, 0f) * rotation.value.zyxw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, -1f, 0f, 0f))).xyz;
        }

        /// <summary>       Returns a <see cref="float3"/> representing the world space forward direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 forward(this quaternion rotation)
        {
            float4 temp = new float4(2f, -2f, 0f, 0f) * rotation.value.yxzw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 0f, 1f, 0f))).xyz;
        }

        /// <summary>       Returns a <see cref="float3"/> representing the world space backward direction relative to a world space <see cref="quaternion"/> rotation.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 back(this quaternion rotation)
        {
            float4 temp = new float4(-2f, 2f, 0f, 0f) * rotation.value.yxzw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 0f, -1f, 0f))).xyz;
        }
    }
}