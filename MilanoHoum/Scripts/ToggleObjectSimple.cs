using UnityEngine;

public class ToggleObjectSimple : MonoBehaviour
{
    // ������ �� ������, ������� ��������/���������
    public GameObject targetObject;

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // ���������� ��������
        }
    }

    // ���� ����� ����� ������� ��� ����� �� �������, �������� ����� UI Button OnClick() 
    // ��� ��� ��������� ������� ����� � ����� ����
    public void ToggleActive()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
