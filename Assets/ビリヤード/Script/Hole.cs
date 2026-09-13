using UnityEngine;

public class Hole : MonoBehaviour
{
    void Start()
    {
    }

    void OnTriggerEnter( Collider other )
    {
        Debug.Log( "落ちたボールの名前 : " + other.gameObject.name );
        // 穴に落ちたボールを非アクティブにする.
        other.gameObject.SetActive( false );
    }
}