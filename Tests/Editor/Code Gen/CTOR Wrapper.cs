using System;
using System.Reflection;

namespace MaxMath.Tests
{
    internal static partial class CodeGen
    {
        internal static string GenerateCTORWrappers()
        {
            string result = string.Empty;
            foreach (Type type in typeof(MaxMath.math).Assembly.GetTypes())
            {
                if (!type.IsPublic)
                {
                    continue;
                }

                foreach (ConstructorInfo ctor in type.GetConstructors())
                {
                    if (!ctor.IsPublic)
                    {
                        continue;
                    }

                    result += $"[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n";
                    result += $"public static {type.Name} {type.Name}(";

                    ParameterInfo[] parameters = ctor.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        result += $"{Reflection.GetTypeName(parameters[i].ParameterType, removeNamespace: false)} {parameters[i].Name}";
                        if (i != parameters.Length - 1)
                        {
                            result += ", ";
                        }
                        else
                        {
                            result += $") => new {type.Name}(";
                        }
                    }
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        result += $"{parameters[i].Name}";
                        if (i != parameters.Length - 1)
                        {
                            result += ", ";
                        }
                        else
                        {
                            result += $");";
                        }
                    }

                    result += "\r\n\r\n";
                }
            }

            result = result.Replace("MaxMath.", string.Empty);
            return result;
        }
    }
}
