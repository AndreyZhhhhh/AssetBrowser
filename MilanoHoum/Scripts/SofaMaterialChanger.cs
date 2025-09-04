using UnityEngine;

public class SofaMaterialChanger : MonoBehaviour
{
    public MeshRenderer[] sofaPartsToChange; // Перетащите сюда MeshRenderer нужных частей дивана
    public Material[] fabricMaterials; // Перетащите сюда список материалов-тканей
    private int currentIndex = 0;

    // Этот метод привяжите к событию On Interact Spatial Interactable
    public void ChangeFabricMaterial()
    {
        currentIndex = (currentIndex + 1) % fabricMaterials.Length;
        foreach (var renderer in sofaPartsToChange)
        {
            renderer.material = fabricMaterials[currentIndex];
        }
    }
}
