using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.3f;
    public float floatFrequency = 1f;
    public float rotateSpeed = 30f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}
