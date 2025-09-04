using UnityEngine;

public class ToggleObjectSimple : MonoBehaviour
{
    // —сылка на объект, который включаем/выключаем
    public GameObject targetObject;

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // изначально выключен
        }
    }

    // Ётот метод нужно вызвать при клике по объекту, например через UI Button OnClick() 
    // или при обработке событи€ клика в вашем коде
    public void ToggleActive()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
