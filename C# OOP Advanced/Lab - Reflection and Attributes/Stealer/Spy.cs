using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigateClass, params string[] requestedFields)
    {
        Type classType = typeof(Hacker);
        FieldInfo[] classFields = classType.GetFields
            (BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investigateClass}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string investigateClass)
    {
        Type type = Type.GetType(investigateClass);
        StringBuilder sb = new StringBuilder();
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var item in fields)
        {
            sb.AppendLine($"{item.Name} must be private!");
        }
        foreach (var item in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} have to be public!");
        }
        foreach (var item in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} must be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);
        MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {type}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");
        foreach (var item in privateMethods)
        {
            sb.AppendLine(item.Name);
        }
        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigateClass)
    {
        Type type = Type.GetType(investigateClass);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (MethodInfo item in methods.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} will return {item.ReturnType}");
        }
        foreach (MethodInfo item in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
        }
        return sb.ToString().Trim();
    }

}