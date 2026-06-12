using UnityEngine;
using Vuforia;

public class ModelTargetDetection : MonoBehaviour
{
    [Header("UI Escaneo")]
    public GameObject escaneandoUI;

    [Header("UI Tutorial")]
    public GameObject tutorialUI;

    private ObserverBehaviour observer;

    private void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }

        // Estado inicial
        escaneandoUI.SetActive(true);
        tutorialUI.SetActive(false);
    }

    private void OnStatusChanged(
        ObserverBehaviour behaviour,
        TargetStatus status)
    {
        bool detected =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED;

        if (detected)
        {
            escaneandoUI.SetActive(false);
            tutorialUI.SetActive(true);
        }
        else
        {
            escaneandoUI.SetActive(true);
            tutorialUI.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnStatusChanged;
        }
    }
}