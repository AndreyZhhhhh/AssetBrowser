using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [Tooltip("Первый объект, который будет переключаться")]
    public GameObject objectA;

    [Tooltip("Второй объект, который будет переключаться")]
    public GameObject objectB;

    private bool isObjectAActive = true;

    void Start()
    {
        // Инициализация: предполагается, что objectA включен, objectB выключен
        if (objectA != null) objectA.SetActive(true);
        if (objectB != null) objectB.SetActive(false);
        isObjectAActive = true;
    }

    // Этот метод будете вызывать через Spatial Interactable при взаимодействии
    public void ToggleObjectsActive()
    {
        if (objectA == null || objectB == null)
        {
            Debug.LogWarning("Один или оба объекта не назначены!");
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
