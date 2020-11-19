using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 left(this quaternion rotation)
        {
            float4 temp = new float4(0f, -2f, 2f, 0f) * rotation.value.wzyx;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(-1f, 0f, 0f, 0f))).xyz;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 right(this quaternion rotation)
        {
            float4 temp = new float4(0f, 2f, -2f, 0f) * rotation.value.wzyx;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(1f, 0f, 0f, 0f))).xyz;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 up(this quaternion rotation)
        {
            float4 temp = new float4(-2f, 0f, 2f, 0f) * rotation.value.zyxw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 1f, 0f, 0f))).xyz;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 down(this quaternion rotation)
        {
            float4 temp = new float4(2f, 0f, -2f, 0f) * rotation.value.zyxw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, -1f, -0f, 0f))).xyz;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 forward(this quaternion rotation)
        {
            float4 temp = new float4(2f, -2f, 0f, 0f) * rotation.value.yxzw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 0f, 1f, 0f))).xyz;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 backward(this quaternion rotation)
        {
            float4 temp = new float4(-2f, 2f, 0f, 0f) * rotation.value.yxzw;
        
            return (((rotation.value.yzxw * temp.zxyw) - (rotation.value.zxyw * temp.yzxw)) + math.mad(temp, rotation.value.wwww, new float4(0f, 0f, -1f, 0f))).xyz;
        }
    }
}