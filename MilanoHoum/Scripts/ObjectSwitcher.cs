using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] sofaVariants; // ������ ��������� �������� ������
    private int currentIndex = 0;

    // �������� ���� ����� ��� �������������� (On Interact)
    public void SwitchSofaObject()
    {
        // ��������� ��� �������
        for (int i = 0; i < sofaVariants.Length; i++)
        {
            sofaVariants[i].SetActive(false);
        }

        // �������� ��������� ������ �� �������
        currentIndex = (currentIndex + 1) % sofaVariants.Length;
        sofaVariants[currentIndex].SetActive(true);
    }
}
