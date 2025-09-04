using UnityEngine;

public class SpecificMaterialChanger : MonoBehaviour
{
    [Tooltip("Материал, который будет установлен при взаимодействии")]
    public Material newMaterial;

    [Tooltip("Индекс материала в массиве materials, который нужно заменить")]
    public int materialIndexToReplace = 0;

    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogWarning("Renderer не найден на объекте.");
        }
        if (newMaterial == null)
        {
            Debug.LogWarning("Новый материал не назначен.");
        }
    }

    // Метод для вызова по событию взаимодействия (например, из Spatial Interactable)
    public void ReplaceMaterialAtIndex()
    {
        if (objectRenderer == null || newMaterial == null) return;

        Material[] mats = objectRenderer.materials;

        if (materialIndexToReplace < 0 || materialIndexToReplace >= mats.Length)
        {
            Debug.LogWarning($"Индекс материала {materialIndexToReplace} вне диапазона. У объекта {mats.Length} материала(ов).");
            return;
        }

        mats[materialIndexToReplace] = newMaterial;
        objectRenderer.materials = mats;

        Debug.Log($"Материал с индексом {materialIndexToReplace} заменён на новый материал.");
    }
}
