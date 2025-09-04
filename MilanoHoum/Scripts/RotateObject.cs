using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("Скорость вращения (градусы в секунду)")]
    public float rotationSpeed = 30f;

    void Update()
    {
        // Вращаем объект вокруг вертикальной оси Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
