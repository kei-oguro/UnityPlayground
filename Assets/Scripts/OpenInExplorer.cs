#if UNITY_EDITOR
using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace MyApp.Editor
{
    public static class OpenInExplorer
    {
        [MenuItem("Debug/Open Path/Persistent Path セーブデータ")]
        public static void OpenPersistentPath() => EditorUtility.RevealInFinder(Application.persistentDataPath);

        [MenuItem("Debug/Open Path/Console Log Path ログ")]
        public static void OpenConsoleLog() => EditorUtility.RevealInFinder(Application.consoleLogPath);

        [MenuItem("Debug/Open Path/Data Path")]
        public static void OpenData() => EditorUtility.RevealInFinder(Application.dataPath);

        [MenuItem("Debug/Open Path/Cache Path")]
        public static void OpenCache() => EditorUtility.RevealInFinder(Application.temporaryCachePath);

        [MenuItem("Debug/Open Path/Editor Application Path")]
        public static void OpenEditorApplication() => EditorUtility.RevealInFinder(EditorApplication.applicationPath);

        [MenuItem("Debug/Open Path/Editor Application Contents Path")]
        public static void OpenEditorApplicationContents() => EditorUtility.RevealInFinder(EditorApplication.applicationContentsPath);

        [MenuItem("Debug/Open Path/Editor Executable")]
        public static void OpenEditorExecutable()
        {
            var mainModule = Process.GetCurrentProcess().MainModule;
            EditorUtility.RevealInFinder(mainModule.FileName);
        }
    }
}
#endif
