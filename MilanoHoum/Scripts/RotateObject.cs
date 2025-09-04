using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Header("�������� �������� (������� � �������)")]
    public float rotationSpeed = 30f;

    void Update()
    {
        // ������� ������ ������ ������������ ��� Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
