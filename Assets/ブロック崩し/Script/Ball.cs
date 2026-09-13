using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(
            (transform.forward + transform.right) * speed,
            ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
