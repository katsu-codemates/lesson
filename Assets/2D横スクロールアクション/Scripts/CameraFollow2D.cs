using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(7f, 0f, -10f);

    private float fixedY;

    void Start()
    {
        //カメラの初期 Y 位置を取得
        fixedY = transform.position.y + offset.y;
    }

    void LateUpdate()
    {
        //プレイヤーのX座標のみ追跡
        Vector3 targetPosition = 
            new Vector3(target.position.x + offset.x, fixedY, offset.z);

        // Lerpを使用することでカメラの動きを滑らかに。
        transform.position = 
            Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}