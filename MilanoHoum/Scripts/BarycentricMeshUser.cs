using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class BarycentricMeshUser : MonoBehaviour
{
    // Этот скрипт можно расширить для работы с материалами, настройками и т.д.
    // Сейчас он просто гарантирует, что компонент есть и может служить точкой расширения.

    void Start()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
        {
            Debug.LogWarning("MeshFilter или меш отсутствует.");
            return;
        }

        // Здесь можно добавить логику, если нужна динамическая работа с мешем или материалом.
    }
}
