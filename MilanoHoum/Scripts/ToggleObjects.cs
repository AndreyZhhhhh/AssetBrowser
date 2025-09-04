using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [Tooltip("������ ������, ������� ����� �������������")]
    public GameObject objectA;

    [Tooltip("������ ������, ������� ����� �������������")]
    public GameObject objectB;

    private bool isObjectAActive = true;

    void Start()
    {
        // �������������: ��������������, ��� objectA �������, objectB ��������
        if (objectA != null) objectA.SetActive(true);
        if (objectB != null) objectB.SetActive(false);
        isObjectAActive = true;
    }

    // ���� ����� ������ �������� ����� Spatial Interactable ��� ��������������
    public void ToggleObjectsActive()
    {
        if (objectA == null || objectB == null)
        {
            Debug.LogWarning("���� ��� ��� ������� �� ���������!");
            return;
        }

        if (isObjectAActive)
        {
            objectA.SetActive(false);
            objectB.SetActive(true);
            isObjectAActive = false;
        }
        else
        {
            objectA.SetActive(true);
            objectB.SetActive(false);
            isObjectAActive = true;
        }
    }
}
