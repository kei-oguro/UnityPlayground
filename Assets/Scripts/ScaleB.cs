using UnityEngine;
using UnityEditor;

public static class ScaleB
{
    [MenuItem("Debug/ScaleB()")]
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
