using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Lesson3.Networking
{
    // UnityWebRequestAsyncOperation はそのままだと await できない(Coroutine前提のAPIのため)。
    // GetAwaiter を生やす拡張メソッドを足すだけで、await request.SendWebRequest(); と書けるようになる。
    public static class UnityWebRequestExtensions
    {
        public static TaskAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<bool>();
            asyncOp.completed += _ => tcs.TrySetResult(true);
            return ((Task)tcs.Task).GetAwaiter();
        }
    }
}
