using UnityEngine;

public class Player : MonoBehaviour
{
    private float accel = 1000.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(
            transform.right * Input.GetAxisRaw("Horizontal") * accel,
            ForceMode.Impulse);
    }
}
