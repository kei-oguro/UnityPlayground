using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// This component returns the static properties of Application class for HTTP request.
/// 
/// The implementation here shows how to respond with Unity objects. We don't need Task if all we need is this, because we can store the result string on the Start() method.
/// </summary>
public class HttpApplicationPropertyPrinter : MonoBehaviour
{
    public string host = "localhost";
    public int port = 8080;
    private HttpListener _listener;
    private readonly ConcurrentQueue<HttpListenerResponse> responseQueue = new();

    void Start()
    {
        _listener = new HttpListener
        {
            Prefixes = { $"http://{host}:{port}/" }
        };
        Debug.Log("Starting Http listener.");
        _listener.Start();
        _/*Fire and Forget*/ = WaitRequest();
    }

    void Update()
    {
        while (responseQueue.TryDequeue(out var response))
        {
            var applicationPropertyString = PrintApplicationProperties.BuildString(new()).ToString();
            response.ContentType = "text/plain";
            var buffer = Encoding.UTF8.GetBytes(applicationPropertyString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.Close();
        }
    }

    private Task WaitRequest()
    {
        return _listener.GetContextAsync()
            .ContinueWith(Response, destroyCancellationToken);
    }

    private void Response(Task<HttpListenerContext> contextTask)
    {
        if (this.IsDestroyed()) return;

        var request = contextTask.Result.Request;
        responseQueue.Enqueue(contextTask.Result.Response);
        _/*Fire and Forget*/ = WaitRequest();
    }

    void Oestroy()
    {
        _listener?.Close();
        Debug.Log("Http listener closed.");
    }
}
