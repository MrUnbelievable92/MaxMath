namespace MaxMath.Tests
{
    internal class FunctionSignature
    {
        internal FunctionSignature(TypeInfo? returnType, Parameter[] parameters)
        {
            ReturnType = returnType;
            Parameters = parameters;
        }
    
        internal TypeInfo? ReturnType;
        internal Parameter[] Parameters;
    }
}
