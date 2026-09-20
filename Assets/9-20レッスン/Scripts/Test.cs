using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Test : MonoBehaviour
{
    public void StartWaitCoroutine()
    {
        StartCoroutine(WaitCoroutine());
        Debug.Log("コルーチン開始");
    }

    public IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("３秒経過");
    }

    public async void StartWaitAsync()
    {
        Debug.Log("待ちはじめ");
        await UniTask.Delay(3000);
        Debug.Log("asyncで三秒経過");
    }
}
