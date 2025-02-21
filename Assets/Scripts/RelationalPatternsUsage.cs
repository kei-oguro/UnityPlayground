#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public static class RelationalPatternsUsage
{
    [MenuItem("Debug/Relatinal Patterns Usage")]
    private static void Execute()
    {
        var x = 0;
        Debug.Log(x is < -1 or >= 1);
        // Debug.Log(x is < -1 and >= 1); // Compiler report this as error that "An expression of type 'int' can never match the provided pattern". That's inteligent.
        Debug.Log(x is < 2 and >= 1);
        Debug.Log($"{x}" is "cat" or "dog");
    }
}
#endif
