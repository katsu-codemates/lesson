using UnityEngine;

public class CameraFollow2D906 : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(7f, 0f, -10f);

    private float fixedY;

    void Start()
    {
        fixedY = transform.position.y + offset.y;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, fixedY, offset.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
