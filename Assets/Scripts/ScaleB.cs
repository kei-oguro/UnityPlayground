using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public static class ScaleB
{
#if UNITY_EDITOR
    [MenuItem("Debug/ScaleB()")]
#endif
    public static void Execute()
    {
        static void Do(float x, int n)
        {
            /* Unfortunately, we can't use ScaleB() yet.
            error CS0117: 'Math' does not contain a definition for 'ScaleB'
            Debug.Log($"ScaleB({x}, {n}) = {System.Math.ScaleB(x, n)}");
            */
        }
    }
}
