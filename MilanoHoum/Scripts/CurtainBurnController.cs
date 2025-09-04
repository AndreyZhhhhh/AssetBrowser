using System.Collections;
using UnityEngine;

public class CurtainBurnController : MonoBehaviour
{
    [Header("�������� ����� � ��������")]
    public Material curtainMaterial;

    [Header("����� �������� ��������� (���)")]
    public float burnDuration = 3f;

    [Header("������������ �������� BurnProgress (��������, 1.5)")]
    public float maxBurnProgress = 1.5f;

    private Coroutine burnCoroutine;

    // ��������� ����� ��� ������� ������� ��������
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
