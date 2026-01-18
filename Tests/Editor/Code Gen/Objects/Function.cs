using System.Linq;
using System.Reflection;

namespace MaxMath.Tests
{
    internal class Function
    {
        internal Function(string name, FunctionSignature signature)
        {
            Name = name;
            Signature = signature;
        }

        internal string Name;
        internal FunctionSignature Signature;

        public static implicit operator Function(MethodInfo m)
        {
            string name = m.Name;
            TypeInfo? returnType = m.ReturnType.Equals(typeof(void)) ? null : Reflection.TypeMap[m.ReturnType];
            Parameter[] parameters = m.GetParameters().Where(p => p.ParameterType != typeof(Promise)).Select(p => (Parameter)p).ToArray();

            return new Function(name, new FunctionSignature(returnType, parameters));
        }

        public override string ToString()
        {
            return $"{ (Signature.ReturnType == null ? "void" : Signature.ReturnType) } { Name }({ CodeGen.GenerateIterated(", ", Signature.Parameters.Length, i => Signature.Parameters[i].ToString()) })";
        }
    }
}
