namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        internal static partial class Constant
        {
            internal static bool IsConstantExpression<T>(T expression) where T : unmanaged => Unity.Burst.CompilerServices.Constant.IsConstantExpression(expression);
            internal static bool IsConstantExpression(void* expression) => Unity.Burst.CompilerServices.Constant.IsConstantExpression(expression);
        }
    }
}