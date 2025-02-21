#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public static class ForceReserializeAssets
{
    [MenuItem("Debug/Force Reserialize All Assets")]
    private static void Execute()
    {
        AssetDatabase.ForceReserializeAssets();
    }
}
#endif