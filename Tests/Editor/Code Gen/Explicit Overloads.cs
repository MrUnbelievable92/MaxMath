using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MaxMath.Tests
{
    public static class ImplicitOverloadGenerator
    {
        public static string GenerateImplicitOverloads(Dictionary<Type, Type[]> conversionMap, Type sourceClass)
        {
            var sb = new StringBuilder();

            var binding = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            var methods = sourceClass.GetMethods(binding)
                                     .Where(m => !m.IsSpecialName && m.IsStatic)
                                     .ToArray();

            var existingSigs = new HashSet<string>();
            foreach (var m in methods)
            {
                existingSigs.Add(SignatureKey(m.Name, m.GetParameters().Select(p => p.ParameterType).ToArray()));
            }

            foreach (var method in methods)
            {
                if (method.IsGenericMethod) continue;
                var parameters = method.GetParameters();
                if (parameters.Any(p => p.ParameterType.IsByRef)) continue;

                foreach (var kv in conversionMap)
                {
                    var targetType = kv.Key;
                    var convertibleTypes = kv.Value ?? Array.Empty<Type>();

                    var indexes = parameters
                                  .Select((p, idx) => new { p, idx })
                                  .Where(x => x.p.ParameterType == targetType)
                                  .Select(x => x.idx)
                                  .ToArray();

                    if (indexes.Length < 2) continue;

                    var choicesPerPosition = indexes
                        .Select(_ => (new Type[] { targetType }).Concat(convertibleTypes).Distinct().ToArray())
                        .ToArray();

                    foreach (var combination in CartesianProduct(choicesPerPosition))
                    {
                        if (combination.All(t => t == targetType)) continue;
                        if (combination.All(t => t != targetType)) continue;

                        var finalParamTypes = parameters
                            .Select((p, i) =>
                            {
                                var posInIndexes = Array.IndexOf(indexes, i);
                                return posInIndexes >= 0 ? combination[posInIndexes] : p.ParameterType;
                            })
                            .ToArray();

                        var sigKey = SignatureKey(method.Name, finalParamTypes);
                        if (existingSigs.Contains(sigKey)) continue;

                        var visibility = method.IsPublic ? "public" : "internal";
                        var returnTypeCode = GetTypeCodeName(method.ReturnType);
                        var methodName = method.Name;

                        var paramDecls = new List<string>();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            var t = finalParamTypes[i];
                            var name = parameters[i].Name ?? ("p" + i);
                            paramDecls.Add($"{GetTypeCodeName(t)} {name}");
                        }

                        var callArgs = new List<string>();
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            var declaredOrig = parameters[i].ParameterType;
                            var provided = finalParamTypes[i];
                            var name = parameters[i].Name ?? ("p" + i);

                            if (provided != declaredOrig)
                            {
                                callArgs.Add($"({GetTypeCodeName(declaredOrig)}){name}");
                            }
                            else
                            {
                                callArgs.Add(name);
                            }
                        }

                        var originalCref = $"M:{sourceClass.FullName}.{methodName}({string.Join(",", parameters.Select(p => CrefTypeName(p.ParameterType)))})";

                        sb.AppendLine("/// <inheritdoc cref=\"" + originalCref + "\" />");
                        sb.AppendLine($"{visibility} static {returnTypeCode} {methodName}({string.Join(", ", paramDecls)})");
                        sb.AppendLine("{");
                        var callPrefix = method.ReturnType == typeof(void) ? "" : "return ";
                        var qualifiedClass = sourceClass.FullName.Contains(".") ? $"{sourceClass.FullName}" : sourceClass.FullName;
                        sb.AppendLine($"    {callPrefix}{qualifiedClass}.{methodName}({string.Join(", ", callArgs)});");
                        sb.AppendLine("}");
                        sb.AppendLine();

                        existingSigs.Add(sigKey);
                    }
                }
            }

            return sb.ToString();
        }

        private static string SignatureKey(string methodName, Type[] paramTypes)
        {
            return methodName + ":" + string.Join(",", paramTypes.Select(t => t.FullName ?? t.Name));
        }

        private static string GetTypeCodeName(Type t)
        {
            if (t == typeof(void)) return "void";
            if (t == typeof(int)) return "int";
            if (t == typeof(uint)) return "uint";
            if (t == typeof(short)) return "short";
            if (t == typeof(ushort)) return "ushort";
            if (t == typeof(byte)) return "byte";
            if (t == typeof(sbyte)) return "sbyte";
            if (t == typeof(long)) return "long";
            if (t == typeof(ulong)) return "ulong";
            if (t == typeof(float)) return "float";
            if (t == typeof(double)) return "double";
            if (t == typeof(decimal)) return "decimal";
            if (t == typeof(bool)) return "bool";
            if (t == typeof(char)) return "char";
            if (t.IsArray)
            {
                return GetTypeCodeName(t.GetElementType()) + "[]";
            }
            if (t.IsGenericType)
            {
                var baseName = t.GetGenericTypeDefinition().FullName;
                var backtick = baseName.IndexOf('`');
                if (backtick >= 0) baseName = baseName.Substring(0, backtick);
                var args = string.Join(", ", t.GetGenericArguments().Select(GetTypeCodeName));
                return $"{baseName}<{args}>";
            }
            return (t.FullName ?? t.Name);
        }

        private static string CrefTypeName(Type t)
        {
            if (t.IsGenericType)
            {
                var def = t.GetGenericTypeDefinition();
                var baseName = def.FullName;
                var backtick = baseName.IndexOf('`');
                if (backtick >= 0) baseName = baseName.Substring(0, backtick);
                var args = string.Join(",", t.GetGenericArguments().Select(CrefTypeName));
                return baseName + "{" + args + "}";
            }
            if (t.IsArray)
            {
                return t.GetElementType().FullName + "[]";
            }
            return t.FullName ?? t.Name;
        }

        private static IEnumerable<Type[]> CartesianProduct(Type[][] choicesPerPosition)
        {
            if (choicesPerPosition == null || choicesPerPosition.Length == 0)
            {
                yield break;
            }

            int[] idx = new int[choicesPerPosition.Length];
            while (true)
            {
                var current = new Type[choicesPerPosition.Length];
                for (int i = 0; i < idx.Length; i++) current[i] = choicesPerPosition[i][idx[i]];
                yield return current;

                int pos = idx.Length - 1;
                while (pos >= 0)
                {
                    idx[pos]++;
                    if (idx[pos] < choicesPerPosition[pos].Length) break;
                    idx[pos] = 0;
                    pos--;
                }
                if (pos < 0) yield break;
            }
        }
    }
}