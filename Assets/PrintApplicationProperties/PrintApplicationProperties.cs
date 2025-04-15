using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class PrintApplicationProperties
{
#if UNITY_EDITOR
    [MenuItem("Debug/Print Application Properties")]
#endif
    public static void Print()
    {
        StringBuilder sb = new();
        BuildString(sb);
        Debug.Log(sb.ToString());
    }

    public static StringBuilder BuildString(StringBuilder sb)
    {
        sb.AppendLine("public static Properties...");
        var publicProperties = typeof(Application).GetProperties(BindingFlags.Static | BindingFlags.Public);
        foreach (var prop in publicProperties
            .Where(prop => prop.CanRead))
        {
            object value = prop.GetValue(null);
            sb.AppendLine($"  {prop.Name}: '{value}'({value?.GetType().Name})");
        }

        sb.AppendLine("");
        sb.AppendLine("Command line arguments...");
        foreach (var (arg, index) in Environment.GetCommandLineArgs().Select((x, i) => (x, i)))
        {
            sb.AppendLine($"  {index,3}: '{arg}'");
        }

        return sb;
    }
}
