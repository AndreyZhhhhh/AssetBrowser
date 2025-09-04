using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BarycentricMeshUser : MonoBehaviour
{
    // ���� ������ ����� ��������� ��� ������ � �����������, ����������� � �.�.
    // ������ �� ������ �����������, ��� ��������� ���� � ����� ������� ������ ����������.

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
        {
            Debug.LogWarning("MeshFilter ��� ��� �����������.");
            return;
        }

        // ����� ����� �������� ������, ���� ����� ������������ ������ � ����� ��� ����������.
    }
}
