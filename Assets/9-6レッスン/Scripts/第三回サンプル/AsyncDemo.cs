using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

// 講座の導入パート(非同期処理の必要性を体感するデモ)で使うサンプル。
// 空のGameObjectに付けて、ボタンのOnClickなどから各メソッドを呼ぶ。
public class AsyncDemo : MonoBehaviour
{
    void Start()
    {
        // RunHeavyLoop();
    }

    // 重い処理をそのまま実行するとフリーズしてしまう
    public void RunHeavyLoop()
    {
        long sum = 0;
        for (int i = 0; i < 2_000_000_000; i++)
        {
            sum += i;
            for (int j = 0; j < 10; j++)
            {
                sum += j;
            }
        }
        Debug.Log($"重い処理が終わりました: {sum}");
    }

    // Coroutine版の3秒待ち
    public void StartWaitCoroutine()
    {
        StartCoroutine(WaitCoroutine());
        Debug.Log("コルーチン開始");
    }

    private IEnumerator WaitCoroutine()
    {
        Debug.Log("(Coroutine) 待ち始め");
        yield return new WaitForSeconds(3f); // ここで三秒待つ
        Debug.Log("(Coroutine) 3秒経過");
    }

    // async/await版の3秒待ち
    public async void StartWaitAsync()
    {
        Debug.Log("(async) 待ち始め");
        await UniTask.Delay(3000);
        Debug.Log("(async) 3秒経過");
    }
}
