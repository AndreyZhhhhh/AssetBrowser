using System.Collections;
using UnityEngine;

public class CurtainBurnController : MonoBehaviour
{
    [Header("Материал шторы с шейдером")]
    public Material curtainMaterial;

    [Header("Время анимации выгорания (сек)")]
    public float burnDuration = 3f;

    [Header("Максимальное значение BurnProgress (например, 1.5)")]
    public float maxBurnProgress = 1.5f;

    private Coroutine burnCoroutine;

    // Публичный метод для запуска эффекта сгорания
    public void StartBurn()
    {
        if (burnCoroutine != null)
            StopCoroutine(burnCoroutine);

        burnCoroutine = StartCoroutine(BurnCoroutine());
    }

    private IEnumerator BurnCoroutine()
    {
        float progress = 0f;

        while (progress < maxBurnProgress)
        {
            progress += Time.deltaTime / burnDuration;
            curtainMaterial.SetFloat("_BurnProgress", progress);
            yield return null;
        }

        curtainMaterial.SetFloat("_BurnProgress", maxBurnProgress);
        burnCoroutine = null;
    }
}
