using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AsyncTest.Editor.Tests
{
    // Shows that we can test with async methods.
    public class AsyncTest
    {
        [Test]
        public void TestsSimplePasses() // Unity created.
        {
        }

        [Test]
        public async Task TestsWithAwaitNextFrame()
        {
            var go = new GameObject("AsyncTest with SampleComponent");
            using var sampleComponent = go.AddComponent<SampleComponent>();
            Assume.That(sampleComponent.Started, Is.EqualTo(false));
            await Awaitable.NextFrameAsync(CancellationToken.None);
            Assert.That(sampleComponent.Started, Is.EqualTo(false/*I learned that Unity doesn't call the lifecycle methods like Awake() and Start()*/));
        }

        [UnityTest]
        public IEnumerator TestsWithEnumeratorPasses() // Unity created.
        {
            yield return null;
        }

        internal class SampleComponent : MonoBehaviour, IDisposable
        {
            public bool Started = false;
            private void Awake() { Debug.Log("Awake"); }
            private void Start()
            {
                Started = true;
            }
            public void Dispose()
            {
                if (Application.isPlaying)
                {
                    Destroy(gameObject);
                }
                else
                {
                    DestroyImmediate(gameObject);
                }
            }
        }
    }
}