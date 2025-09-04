using UnityEngine;

public class MultipleMaterialsToggleChanger : MonoBehaviour
{
    [Tooltip("����� ���������, ������� ����� �����������")]
    public Material[] newMaterials;

    [Tooltip("������� ���������� �� �������, ������� ����� ��������")]
    public int[] materialIndicesToReplace;

    private Renderer objectRenderer;
    private Material[] originalMaterials;
    private bool isUsingNewMaterials = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer �� ������ �� �������.");
            return;
        }

        // �������� ������������ ��������� ��� ��������
        originalMaterials = objectRenderer.materials;

        if (newMaterials == null || newMaterials.Length == 0)
            Debug.LogWarning("����� ��������� �� ���������.");

        if (materialIndicesToReplace == null || materialIndicesToReplace.Length == 0)
            Debug.LogWarning("������� ���������� ��� ������ �� ������.");

        if (newMaterials.Length != materialIndicesToReplace.Length)
            Debug.LogWarning("���������� ����� ���������� � ���������� �������� ������ �� ���������.");
    }

    // ����� ������������ ���������� ��� ������ �� Spatial Interactable
    public void ToggleMaterials()
    {
        if (objectRenderer == null || newMaterials == null || materialIndicesToReplace == null) return;

        Material[] mats = objectRenderer.materials;

        if (!isUsingNewMaterials)
        {
            // �������� ��������� ��������� �� �����
            int count = Mathf.Min(newMaterials.Length, materialIndicesToReplace.Length);

            for (int i = 0; i < count; i++)
            {
                int index = materialIndicesToReplace[i];
                if (index < 0 || index >= mats.Length)
                {
                    Debug.LogWarning($"������ ��������� {index} ��� ���������. � ������� {mats.Length} ���������(��).");
                    continue;
                }
                mats[index] = newMaterials[i];
            }

            objectRenderer.materials = mats;
            isUsingNewMaterials = true;
            Debug.Log($"��������� �������� �� �����.");
        }
        else
        {
            // ���������� ������������ ��������� ������ �� �������� ��������
            // ����� �� ������ ������ ���������, ������� ����� ����������:
            for (int i = 0; i < materialIndicesToReplace.Length; i++)
            {
                int index = materialIndicesToReplace[i];
                if (index < 0 || index >= mats.Length || index >= originalMaterials.Length) continue;
                mats[index] = originalMaterials[index];
            }

            objectRenderer.materials = mats;
            isUsingNewMaterials = false;
            Debug.Log($"��������� ���������� � ������������.");
        }
    }
}
