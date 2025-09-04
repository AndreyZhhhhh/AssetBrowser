using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject[] sofaVariants; // Массив вариантов объектов дивана
    private int currentIndex = 0;

    // Вызывать этот метод при взаимодействии (On Interact)
    public void SwitchSofaObject()
    {
        // Отключаем все объекты
        for (int i = 0; i < sofaVariants.Length; i++)
        {
            sofaVariants[i].SetActive(false);
        }

        // Включаем следующий объект по индексу
        currentIndex = (currentIndex + 1) % sofaVariants.Length;
        sofaVariants[currentIndex].SetActive(true);
    }
}
