#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using Unity.Collections;
using System.Collections.Generic;

public static class SpanUsage
{
    [MenuItem("Debug/Span Usage")]
    private static void Execute()
    {
        {
            var array = new[] { 1, 2, 3 };
            var span = new ReadOnlySpan<int>(array);
            Debug.Log(Sum(span));
        }

        {
            ReadOnlySpan<int> span = stackalloc int[3] { 4, 5, 6 };
            Debug.Log(Sum(span));
        }

        {
            var nativeArray = new NativeArray<int>(new[] { 7, 8, 9 }, Allocator.Temp);
            var span = nativeArray.AsSpan();
            Debug.Log(Sum(span));
        }

#if false // Unity 6000 doesn't yet support collection expression.
        {
            ReadOnlySpan<int> span = [10, 11, 12];
            Console.WriteLine(Sum(span));
        }
#endif

#if false // We don't have CollectionsMarshal.AsSpan() in Unity 6000 even though it's .net standard 2.1.
        {
            var list = new List<int> { 13, 14, 15 };
            ReadOnlySpan<int> span = System.Runtime.InteropServices.CollectionsMarshal.AsSpan(list);
        }
#endif
    }

    private static int Sum(ReadOnlySpan<int> span)
    {
        int sum = 0;
        foreach (var value in span)
        {
            sum += value;
        }
        return sum;
    }
}
#endif
