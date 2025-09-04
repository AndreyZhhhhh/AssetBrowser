using UnityEngine;

public class SpecificMaterialChanger : MonoBehaviour
{
    [Tooltip("��������, ������� ����� ���������� ��� ��������������")]
    public Material newMaterial;

    [Tooltip("������ ��������� � ������� materials, ������� ����� ��������")]
    public int materialIndexToReplace = 0;

    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer �� ������ �� �������.");
        }
        if (newMaterial == null)
        {
            Debug.LogWarning("����� �������� �� ��������.");
        }
    }

    // ����� ��� ������ �� ������� �������������� (��������, �� Spatial Interactable)
    public void ReplaceMaterialAtIndex()
    {
        if (objectRenderer == null || newMaterial == null) return;

        Material[] mats = objectRenderer.materials;

        if (materialIndexToReplace < 0 || materialIndexToReplace >= mats.Length)
        {
            Debug.LogWarning($"������ ��������� {materialIndexToReplace} ��� ���������. � ������� {mats.Length} ���������(��).");
            return;
        }

        mats[materialIndexToReplace] = newMaterial;
        objectRenderer.materials = mats;

        Debug.Log($"�������� � �������� {materialIndexToReplace} ������ �� ����� ��������.");
    }
}
