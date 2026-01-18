using System.Reflection;

namespace MaxMath.Tests
{
    internal class Parameter
    {
        internal enum Reference
        {
            Value,
            Ref,
            In,
            Out
        }

        internal Parameter(string name, TypeInfo type, Reference passBy)
        {
            Name = name;
            Type = type;
            PassBy = passBy;
        }

        internal string Name;
        internal TypeInfo Type;
        internal Reference PassBy;

        public static implicit operator Parameter(ParameterInfo p)
        {
            string name = p.Name;
            TypeInfo type = Reflection.TypeMap[p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType];
            Reference passBy = p.IsIn ? Reference.In : p.IsOut ? Reference.Out : p.ParameterType.IsByRef ? Reference.Ref : Reference.Value;

            return new Parameter(name, type, passBy);
        }


        public override string ToString()
        {
            string result = PassBy == Reference.Value ? string.Empty
                                                      : PassBy.ToString().ToLower() + " ";
            return $"{ result }{ Type } { Name}";
        }
    }
}
