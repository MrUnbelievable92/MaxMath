using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    internal class Reflection
    {
        static Reflection()
        {
            List<TypeInfo> maxmathTypes = new List<TypeInfo>();

            maxmathTypes.AddRange(TypeInfo.AllScalarTypes);
            maxmathTypes.AddRange(TypeInfo.AllVectorTypes);
            maxmathTypes.AddRange(TypeInfo.AllMatrixTypes);

            IEnumerable<Type> cleaned = MaxMathTypes.Where(type => maxmathTypes.Any(maxmathType => maxmathType.ToString() == type.Name));
            cleaned = cleaned.Concat(UnityMathematicsTypes.Where(type => maxmathTypes.Any(maxmathType => maxmathType.ToString() == type.Name)));

            TypeMap = new Dictionary<Type, TypeInfo>(cleaned.Select(type => maxmathTypes.Where(maxmathType => type.Name == maxmathType.ToString())
                                                                                        .Select(maxmathType => new KeyValuePair<Type, TypeInfo>(type, maxmathType)).First()));
            foreach (KeyValuePair<Type, TypeInfo> systemType in SystemTypes)
            {
                TypeMap.Add(systemType.Key, systemType.Value);
            }
        }


        private const BindingFlags PUBLIC_GLOBAL = BindingFlags.Public | BindingFlags.Static;
        private const BindingFlags PUBLIC_MEMBER = BindingFlags.Public | BindingFlags.Instance;

        internal static Dictionary<Type, TypeInfo> TypeMap;

        internal static Type[] AllTypes
        {
            get
            {
                List<Type> result = new List<Type>();

                foreach (MethodInfo function in typeof(maxmath).GetMethods(BindingFlags.Public | BindingFlags.Static))
                {
                    if (!result.Contains(function.ReturnType))
                    {
                        result.Add(function.ReturnType);
                    }

                    foreach (ParameterInfo parameter in function.GetParameters())
                    {
                        if (!result.Contains(parameter.ParameterType.IsByRef ? parameter.ParameterType.GetElementType() : parameter.ParameterType))
                        {
                            result.Add(parameter.ParameterType.IsByRef ? parameter.ParameterType.GetElementType() : parameter.ParameterType);
                        }
                    }
                }

                return result.ToArray();
            }
        }

        internal static Dictionary<Type, TypeInfo> SystemTypes
        {
            get
            {
                return new Dictionary<Type, TypeInfo>
                {
                    { typeof(bool),      new TypeInfo(sizeof(bool),      1, 1, Signedness.Unsigned, NumericDataType.Boolean) },

                    { typeof(byte),      new TypeInfo(sizeof(byte),      1, 1, Signedness.Unsigned, NumericDataType.Integer) },
                    { typeof(ushort),    new TypeInfo(sizeof(ushort),    1, 1, Signedness.Unsigned, NumericDataType.Integer) },
                    { typeof(uint),      new TypeInfo(sizeof(uint),      1, 1, Signedness.Unsigned, NumericDataType.Integer) },
                    { typeof(ulong),     new TypeInfo(sizeof(ulong),     1, 1, Signedness.Unsigned, NumericDataType.Integer) },

                    { typeof(sbyte),     new TypeInfo(sizeof(sbyte),     1, 1, Signedness.Signed, NumericDataType.Integer) },
                    { typeof(short),     new TypeInfo(sizeof(short),     1, 1, Signedness.Signed, NumericDataType.Integer) },
                    { typeof(int),       new TypeInfo(sizeof(int),       1, 1, Signedness.Signed, NumericDataType.Integer) },
                    { typeof(long),      new TypeInfo(sizeof(long),      1, 1, Signedness.Signed, NumericDataType.Integer) },

                    { typeof(float),     new TypeInfo(sizeof(float),     1, 1, Signedness.Signed, NumericDataType.FloatingPoint) },
                    { typeof(double),    new TypeInfo(sizeof(double),    1, 1, Signedness.Signed, NumericDataType.FloatingPoint) },
                };
            }
        }

        internal static IEnumerable<Type> UnityMathematicsTypes
        {
            get
            {
                return typeof(math).Assembly.GetExportedTypes().Where(t => t.IsValueType);
            }
        }

        internal static IEnumerable<Type> MaxMathTypes
        {
            get
            {
                return typeof(maxmath).Assembly.GetExportedTypes().Where(t => t.IsValueType);
            }
        }

        internal static IEnumerable<Function> Functions
        {
            get
            {
                return typeof(maxmath).GetMethods(PUBLIC_GLOBAL).Select(function => (Function)function);
            }
        }

        //internal static List<(TypeInfo, Function)> Methods
        //{
        //    get
        //    {
        //        List<string> result = new();
        //
        //        foreach (MethodInfo function in typeof(maxmath).GetMethods(PUBLIC_MEMBER))
        //        {
        //
        //        }
        //    }
        //}


        private static string RemoveNamespace(string s)
        {
            return s.Substring(s.LastIndexOf('.') + 1);
        }

        private static string RemovePointerSyntax(string s)
        {
            s = s.Replace("*", string.Empty);
            s = s.Replace("&", string.Empty);

            return s;
        }

        internal static string GetTypeName(Type type)
        {
            switch (RemovePointerSyntax(RemoveNamespace(type.Name)))
            {
                case "Void": return "void";

                case "Boolean": return "bool";

                case "Byte":    return "byte";
                case "UInt16":  return "ushort";
                case "UInt32":  return "uint";
                case "UInt64":  return "ulong";

                case "SByte":   return "sbyte";
                case "Int16":   return "short";
                case "Int32":   return "int";
                case "Int64":   return "long";

                case "Single":  return "float";
                case "Double":  return "double";

                default: return RemovePointerSyntax(RemoveNamespace(type.Name));
            }
        }

        internal static string ToSourceCode(MethodInfo m, bool parameterNames, out string returnType, out string[] parameterTypes)
        {
            returnType = GetTypeName(m.ReturnType);
            string parameters = ToSourceCode(m.GetParameters(), parameterNames, out parameterTypes);

            return $"{ returnType } { m.Name }({ parameters })";
        }

        internal static string ToSourceCode(ParameterInfo[] ps, bool names, out string[] typeNames)
        {
            typeNames = ps.Select(p => GetTypeName(p.ParameterType)).ToArray();

            return CodeGen.GenerateIterated(
            ", ",
            ps.Length,
            i =>
            {
                return (ps[i].IsIn ? "in " : ps[i].IsOut ? "out " : ps[i].ParameterType.IsByRef ? "ref " : string.Empty)
                     + GetTypeName(ps[i].ParameterType)
                     + (names ? " " + ps[i].Name : string.Empty);
            });
        }
    }
}
