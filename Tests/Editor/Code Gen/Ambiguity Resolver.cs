using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MaxMath.Tests
{
    public static class MathOverloadGenerator
    {
        public static string GenerateOverloads((Type unity, Type wrap)[] mapping)
        {
            var sb = new StringBuilder();
            var mapWrapToUnity = mapping.ToDictionary(t => t.wrap, t => t.unity);
            var mapUnityToWrap = mapping.ToDictionary(t => t.unity, t => t.wrap);
    
            var generatedSignatures = new HashSet<string>();
    
            string ns = typeof(math).Namespace ?? "MaxMath";
            string className = typeof(math).Name;
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine($"namespace {ns}");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic static partial class {className}");
            sb.AppendLine("\t{");
    
            var methods = typeof(math).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                                        .Where(m => !m.IsSpecialName && !m.IsGenericMethod);
    
            foreach (var mi in methods)
            {
                var parameters = mi.GetParameters();
                var wrapperIndices = new List<int>();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var pType = parameters[i].ParameterType;
                    if (pType.IsByRef) pType = pType.GetElementType();
                    if (mapWrapToUnity.ContainsKey(pType))
                        wrapperIndices.Add(i);
                }
    
                if (wrapperIndices.Count == 0) continue;
    
                int n = wrapperIndices.Count;
                int subsets = (1 << n);
    
                for (int mask = 1; mask < subsets; mask++)
                {
                    var newParamTypes = new Type[parameters.Length];
                    var newParamModifiers = new string[parameters.Length];
                    var paramNames = new string[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var p = parameters[i];
                        var baseType = p.ParameterType;
                        bool isByRef = baseType.IsByRef;
                        Type elementType = isByRef ? baseType.GetElementType() : baseType;
                        newParamTypes[i] = elementType;
                        newParamModifiers[i] = p.IsOut ? "out" : (isByRef ? "ref" : "");
                        paramNames[i] = p.Name;
                    }
    
                    for (int bit = 0; bit < n; bit++)
                    {
                        if ((mask & (1 << bit)) == 0) continue;
                        int paramIndex = wrapperIndices[bit];
                        var wrapperType = parameters[paramIndex].ParameterType;
                        if (wrapperType.IsByRef) wrapperType = wrapperType.GetElementType();
                        var unityType = mapWrapToUnity[wrapperType];
                        newParamTypes[paramIndex] = unityType;
                    }
    
                    if (SignatureExistsOnType(typeof(math), mi.Name, newParamTypes, newParamModifiers))
                        continue;
    
                    string sigKey = $"{mi.Name}({string.Join(",", newParamTypes.Select(t => t.FullName))})";
                    if (generatedSignatures.Contains(sigKey)) continue;
                    generatedSignatures.Add(sigKey);
    
                    string originalCref = MakeCrefForMethod(mi);
                    sb.AppendLine("\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]");
                    sb.AppendLine("\t\t/// <inheritdoc cref=\"" + originalCref + "\" />");
    
                    string returnTypeName = GetTypeNameForCode(mi.ReturnType);
                    var paramDecls = new List<string>();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        string modifier = newParamModifiers[i];
                        string typeName = GetTypeNameForCode(newParamTypes[i]);
                        string name = paramNames[i];
                        if (string.IsNullOrEmpty(name)) name = "p" + i;
                        if (parameters[i].HasDefaultValue)
                        {
                            paramDecls.Add($"{modifier} {typeName} {name} = {(parameters[i].ParameterType == typeof(Promise) ? "Promise." : string.Empty) }{(parameters[i].ParameterType == typeof(bool) ? parameters[i].DefaultValue.ToString().ToLower() : parameters[i].DefaultValue)}".Trim());
                        }
                        else
                        {
                            paramDecls.Add($"{modifier} {typeName} {name}".Trim());
                        }
                    }
    
                    string methodModifiers = "public static";
                    sb.AppendLine($"\t\t{methodModifiers} {returnTypeName} {mi.Name}({string.Join(", ", paramDecls)})");
                    sb.AppendLine("\t\t{");
    
                    var callArgs = new List<string>();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var p = parameters[i];
                        bool isByRef = p.ParameterType.IsByRef;
                        string byRefKeyword = p.IsOut ? "out" : (isByRef ? "ref" : "");
                        string name = paramNames[i];
    
                        Type originalElementType = p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType;
                        Type suppliedType = newParamTypes[i];
    
                        string expr;
                        if (TypesEqualIgnoringByRef(originalElementType, suppliedType))
                        {
                            expr = name;
                        }
                        else
                        {
                            expr = GetConversionExpression(suppliedType, originalElementType, name);
                        }
    
                        callArgs.Add($"{byRefKeyword} {expr}".Trim());
                    }
    
                    string call = $"{mi.Name}({string.Join(", ", callArgs)})";
                    if (mi.ReturnType == typeof(void))
                        sb.AppendLine($"\t\t\t{call};");
                    else
                        sb.AppendLine($"\t\t\treturn {call};");
    
                    sb.AppendLine("\t\t}");
                    sb.AppendLine();
                }
            }
    
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            string result = sb.ToString();
            return result.Replace("MaxMath.", string.Empty);
        }
    
        static bool TypesEqualIgnoringByRef(Type a, Type b)
        {
            if (a == b) return true;
            return a.FullName == b.FullName;
        }
    
        static string GetConversionExpression(Type fromType, Type toType, string paramName)
        {
            if (fromType == toType) return paramName;
            return $"({GetTypeNameForCode(toType)}){paramName}";
        }
    
        static bool SignatureExistsOnType(Type type, string methodName, Type[] paramTypes, string[] paramModifiers)
        {
            var candidates = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                                 .Where(m => m.Name == methodName && !m.IsGenericMethod);
            foreach (var m in candidates)
            {
                var ps = m.GetParameters();
                if (ps.Length != paramTypes.Length) continue;
                bool ok = true;
                for (int i = 0; i < ps.Length; i++)
                {
                    var p = ps[i];
                    Type pType = p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType;
                    if (pType.FullName != paramTypes[i].FullName) { ok = false; break; }
                    bool pIsByRef = p.ParameterType.IsByRef;
                    bool suppliedIsByRef = !string.IsNullOrEmpty(paramModifiers[i]);
                    if (pIsByRef != suppliedIsByRef) { ok = false; break; }
                }
                if (ok) return true;
            }
            return false;
        }
    
        static string GetTypeNameForCode(Type t)
        {
            if (t == null) return "void";
            if (t.IsByRef) t = t.GetElementType();
    
            if (t.IsGenericType)
            {
                var genericDef = t.GetGenericTypeDefinition();
                var genName = genericDef.FullName;
                int backtick = genName.IndexOf('`');
                if (backtick >= 0) genName = genName.Substring(0, backtick);
                var genArgs = t.GetGenericArguments().Select(a => GetTypeNameForCode(a)).ToArray();
                return $"{genName}<{string.Join(", ", genArgs)}>";
            }
    
            if (t == typeof(void)) return "void";
            if (t == typeof(int)) return "int";
            if (t == typeof(uint)) return "uint";
            if (t == typeof(short)) return "short";
            if (t == typeof(ushort)) return "ushort";
            if (t == typeof(long)) return "long";
            if (t == typeof(ulong)) return "ulong";
            if (t == typeof(byte)) return "byte";
            if (t == typeof(sbyte)) return "sbyte";
            if (t == typeof(float)) return "float";
            if (t == typeof(double)) return "double";
            if (t == typeof(bool)) return "bool";
            if (t == typeof(char)) return "char";
            if (t.FullName == null) return t.Name;
            return $"{t.FullName}";
        }
    
        static string MakeCrefForMethod(MethodInfo mi)
        {
            var paramList = string.Join(", ", mi.GetParameters().Select(p => p.ParameterType.IsByRef
                                                                            ? GetTypeNameForCode(p.ParameterType.GetElementType())
                                                                            : GetTypeNameForCode(p.ParameterType)));
            var typeName = GetTypeNameForCode(mi.DeclaringType);
            return $"{typeName}.{mi.Name}({paramList})";
        }
    }
}
