using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

// 講座の導入パート(非同期処理の必要性を体感するデモ)で使うサンプル。
// 空のGameObjectに付けて、ボタンのOnClickなどから各メソッドを呼ぶ。
public class AsyncDemo : MonoBehaviour
{
    // 重い処理をそのまま実行し、フレームが固まる様子を見せる
    public void RunHeavyLoop()
    {
        Debug.Log("重い処理を開始します");
        long sum = 0;
        for (int i = 0; i < 2_000_000_000; i++)
        {
            sum += i;
        }
        Debug.Log($"重い処理が終わりました: {sum}");
    }

    // Coroutine版の3秒待ち
    public void StartWaitCoroutine()
    {
        StartCoroutine(WaitCoroutine());
    }

    private IEnumerator WaitCoroutine()
    {
        Debug.Log("(Coroutine) 待ち始め");
        yield return new WaitForSeconds(3f);
        Debug.Log("(Coroutine) 3秒経過");
    }

    // async/await版の3秒待ち
    public async void StartWaitAsync()
    {
        Debug.Log("(async) 待ち始め");
        await Task.Delay(3000);
        Debug.Log("(async) 3秒経過");
    }
}
