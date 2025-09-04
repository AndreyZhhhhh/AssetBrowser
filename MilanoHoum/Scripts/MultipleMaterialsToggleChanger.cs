using UnityEngine;

public class MultipleMaterialsToggleChanger : MonoBehaviour
{
    [Tooltip("Новые материалы, которые будут установлены")]
    public Material[] newMaterials;

    [Tooltip("Индексы материалов на объекте, которые нужно заменить")]
    public int[] materialIndicesToReplace;

    private Renderer objectRenderer;
    private Material[] originalMaterials;
    private bool isUsingNewMaterials = false;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer не найден на объекте.");
            return;
        }

        // Копируем оригинальные материалы для возврата
        originalMaterials = objectRenderer.materials;

        if (newMaterials == null || newMaterials.Length == 0)
            Debug.LogWarning("Новые материалы не назначены.");

        if (materialIndicesToReplace == null || materialIndicesToReplace.Length == 0)
            Debug.LogWarning("Индексы материалов для замены не заданы.");

        if (newMaterials.Length != materialIndicesToReplace.Length)
            Debug.LogWarning("Количество новых материалов и количество индексов замены не совпадает.");
    }

    // Метод переключения материалов для вызова из Spatial Interactable
    public void ToggleMaterials()
    {
        if (objectRenderer == null || newMaterials == null || materialIndicesToReplace == null) return;

        Material[] mats = objectRenderer.materials;

        if (!isUsingNewMaterials)
        {
            // Заменяем указанные материалы на новые
            int count = Mathf.Min(newMaterials.Length, materialIndicesToReplace.Length);

            for (int i = 0; i < count; i++)
            {
                int index = materialIndicesToReplace[i];
                if (index < 0 || index >= mats.Length)
                {
                    Debug.LogWarning($"Индекс материала {index} вне диапазона. У объекта {mats.Length} материала(ов).");
                    continue;
                }
                mats[index] = newMaterials[i];
            }

            objectRenderer.materials = mats;
            isUsingNewMaterials = true;
            Debug.Log($"Материалы заменены на новые.");
        }
        else
        {
            // Возвращаем оригинальные материалы только по заданным индексам
            // Чтобы не менять другие материалы, которые могли измениться:
            for (int i = 0; i < materialIndicesToReplace.Length; i++)
            {
                int index = materialIndicesToReplace[i];
                if (index < 0 || index >= mats.Length || index >= originalMaterials.Length) continue;
                mats[index] = originalMaterials[index];
            }

            objectRenderer.materials = mats;
            isUsingNewMaterials = false;
            Debug.Log($"Материалы возвращены к оригинальным.");
        }
    }
}
