using UnityEngine;

public class SofaMaterialChanger : MonoBehaviour
{
    public MeshRenderer[] sofaPartsToChange; // ���������� ���� MeshRenderer ������ ������ ������
    public Material[] fabricMaterials; // ���������� ���� ������ ����������-������
    private int currentIndex = 0;

    // ���� ����� ��������� � ������� On Interact Spatial Interactable
    public void ChangeFabricMaterial()
    {
        currentIndex = (currentIndex + 1) % fabricMaterials.Length;
        foreach (var renderer in sofaPartsToChange)
        {
            renderer.material = fabricMaterials[currentIndex];
        }
    }
}
