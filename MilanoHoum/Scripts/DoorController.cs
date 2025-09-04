using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [Header("Настройки анимации двери")]
    [Tooltip("Угол поворота двери при открытии (по оси Y).")]
    public float openAngleY = 90f;
    [Tooltip("Скорость анимации (градусов в секунду).")]
    public float animationSpeed = 120f;
    [Tooltip("Автоматически закрывать дверь через это время (сек). Если 0 — не закрывать автоматически.")]
    public float autoCloseDelay = 0f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private bool isOpen = false;
    private bool isAnimating = false;
    private Coroutine autoCloseCoroutine;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    // Этот метод вызывается Spatial Interactable компонентом
    public void ToggleDoor()
    {
        if (isAnimating) return;

        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        if (isAnimating) return;
        isOpen = true;
        targetRotation = Quaternion.Euler(transform.eulerAngles.x, initialRotation.eulerAngles.y + openAngleY, transform.eulerAngles.z);
        StartCoroutine(RotateDoor(targetRotation));
        if (autoCloseDelay > 0)
        {
            if (autoCloseCoroutine != null) StopCoroutine(autoCloseCoroutine);
            autoCloseCoroutine = StartCoroutine(AutoCloseAfterDelay());
        }
    }

    public void CloseDoor()
    {
        if (isAnimating) return;
        isOpen = false;
        targetRotation = initialRotation;
        StartCoroutine(RotateDoor(targetRotation));
    }

    private IEnumerator AutoCloseAfterDelay()
    {
        yield return new WaitForSeconds(autoCloseDelay);
        CloseDoor();
    }

    private IEnumerator RotateDoor(Quaternion targetRot)
    {
        isAnimating = true;
        while (Quaternion.Angle(transform.rotation, targetRot) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, animationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRot;
        isAnimating = false;
    }
}
