using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using UnityEditor;

namespace MaxMath.Tests
{
    // This setup doesn't catch extension methods
    public static class _testcoverage
    {
        private const BindingFlags METHODS_TO_COVER = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

        private static string[] EXCLUDED_TYPES = { "Promise" };
        private static string[] EXCLUDED_TYPE_METHODS = { "get_zero", "get_identity", "GetType", "GetHashCode" };

        private static IEnumerable<Type> MaxMathTypes => typeof(maxmath).Assembly.GetExportedTypes().Where(t => t.IsValueType && !EXCLUDED_TYPES.Contains(t.Name));

        private static List<string> MaxMathFunctions
        {
            get
            {
                List<string> result = new();

                foreach (MethodInfo function in typeof(maxmath).GetMethods(METHODS_TO_COVER))
                {
                    if (EXCLUDED_TYPE_METHODS.Contains(function.Name))
                    {
                        continue;
                    }

                    result.Add(function.Name +
                               '<' +
                               StandardizeTypeName(function.GetParameters()[0].ParameterType.Name) +
                               '>');
                }

                return result;
            }
        }

        private static List<string> MaxMathTests
        {
            get
            {
                List<string> result = new();

                foreach (Type testGroup in typeof(_testcoverage).Assembly.GetTypes().Where(t => t.Name.StartsWith("f_")))
                {
                    foreach (MethodInfo test in testGroup.GetMethods(METHODS_TO_COVER))
                    {
                        result.Add(testGroup.Name.Substring(2) +
                                   '<' +
                                   test.Name.Substring(1) +
                                   '>');
                    }
                }

                return result;
            }
        }

        private static string RemoveGenerics(string obj)
        {
            return obj.Replace("`1", "");
        }

        private static string StandardizeTypeName(string type)
        {
            string result;

            switch (type)
            {
                case "Boolean": result = "bool"; break;

                case "Byte":    result = "byte"; break;
                case "UInt16":  result = "ushort"; break;
                case "UInt32":  result = "uint"; break;
                case "UInt64":  result = "ulong"; break;

                case "SByte":   result = "sbyte"; break;
                case "Int16":   result = "short"; break;
                case "Int32":   result = "int"; break;
                case "Int64":   result = "long"; break;

                case "Single":  result = "float"; break;
                case "Double":  result = "double"; break;

                default: result = type; break;
            }

            return RemoveGenerics(result);
        }

        private static string GetSecondParameterType(Type containingType, MethodInfo method)
        {
            ParameterInfo[] parameters = method.GetParameters();

            if (parameters.Length == 1)
            {
                return '<' + StandardizeTypeName(parameters[0].ParameterType.Name) + '>';
            }
            else
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType != containingType)
                    {
                        return '<' + StandardizeTypeName(parameters[i].ParameterType.Name) + '>';
                    }
                }

                return '<' + StandardizeTypeName(containingType.Name) + '>';
            }
        }

        private static string GetTypedName(MethodInfo test, Type containingType)
        {
            string name = RemoveGenerics(test.Name);
            int index = name.LastIndexOf('_');

            if (index <= 3) // "_byte" ; "op_Division ; get/set_"
            {
                name += '<' + containingType.Name.Substring(2) + '>';
            }
            else
            {
                name = name.Remove(index, 1);
                name = name.Insert(index, "<");
                name += '>';
            }

            return name;
        }

        private static void ThrowIfNotEmpty(IEnumerable<string> missingUnitTests)
        {
            if (missingUnitTests.Count() != 0)
            {
                string print = $"The following { missingUnitTests.Count() } functions are not covered by unit tests:\n\n";

                foreach (string missingUnitTest in missingUnitTests)
                {
                    print += missingUnitTest + '\n';
                }

                throw new NotImplementedException(print);
            }
        }


        [Test]
        public static void Functions()
        {
            IEnumerable<string> tests = MaxMathTests;
            IEnumerable<string> types = MaxMathTypes.Select(_type => RemoveGenerics(_type.Name));
            IEnumerable<string> missingUnitTests = MaxMathFunctions.Where(name => !tests.Contains(name) && !types.Contains(name));

            ThrowIfNotEmpty(missingUnitTests);
        }

        [Test]
        public static void Types()
        {
            IEnumerable<Type> typesToCover = MaxMathTypes;
            List<string> typesAndMethodsToCover = new();

            foreach (Type type in typesToCover)
            {
                if (EXCLUDED_TYPES.Contains(RemoveGenerics(type.Name)))
                {
                    continue;
                }

                foreach (MethodInfo method in type.GetMethods(METHODS_TO_COVER))
                {
                    if (EXCLUDED_TYPE_METHODS.Contains(method.Name))
                    {
                        continue;
                    }

                    ParameterInfo[] parameters = method.GetParameters();

                    if (parameters.Length != 0
                     && parameters[0].ParameterType == typeof(object))
                    {
                        continue;
                    }

                    string name = RemoveGenerics(type.Name) + '.';

                    if (method.Name == "op_Implicit"
                     || method.Name == "op_Explicit")
                    {
                        if (method.ReturnType.Name == type.Name)
                        {
                            name += "op_ConvertFrom<" + StandardizeTypeName(parameters[0].ParameterType.Name) + '>';
                        }
                        else
                        {
                            name += "op_ConvertTo<" + StandardizeTypeName(method.ReturnType.Name) + '>';
                        }
                    }
                    else
                    {
                        name += method.Name + GetSecondParameterType(type, method);
                    }

                    typesAndMethodsToCover.Add(name);
                }
            }

            IEnumerable<Type> coveredTypes = typeof(_testcoverage).Assembly.GetTypes().Where(t => t.Name.StartsWith("t_"));
            List<string> coveredTypesAndMethods = new();

            foreach (Type coveredType in coveredTypes)
            {
                foreach (MethodInfo method in coveredType.GetMethods(METHODS_TO_COVER))
                {
                    coveredTypesAndMethods.Add(coveredType.Name.Substring(2) + '.' + GetTypedName(method, coveredType));
                }
            }

            IEnumerable<string> missingUnitTests = typesAndMethodsToCover.Where(name => !coveredTypesAndMethods.Contains(name));

            ThrowIfNotEmpty(missingUnitTests);
        }

        [Test]
        public static void Promises()
        {
            throw new NotImplementedException();
        }

        [Test]
        public static void Const()
        {
            throw new NotImplementedException();
        }
    }
}
