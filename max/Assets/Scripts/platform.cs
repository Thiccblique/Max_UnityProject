using UnityEngine;

public class platform : MonoBehaviour
{

    float initialZposition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialZposition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float newZ = 3*Mathf.Sin(Time.time * 5 );
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ + initialZposition);
    }
}
