using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [Header("Pasos AR")]
    public GameObject[] tutorialSteps;

    [Header("UI")]
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public TMP_Text stepCounterText;

    private int currentStep = 0;

    [Header("Contenido")]
    public string[] titles;
    public string[] descriptions;

    void Start()
    {
        UpdateTutorial();
    }

    public void NextStep()
    {
        if (currentStep < tutorialSteps.Length - 1)
        {
            currentStep++;
            UpdateTutorial();
        }
    }

    public void PreviousStep()
    {
        if (currentStep > 0)
        {
            currentStep--;
            UpdateTutorial();
        }
    }

    void UpdateTutorial()
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == currentStep);
        }

        titleText.text = titles[currentStep];

        descriptionText.text = descriptions[currentStep];

        stepCounterText.text =
            (currentStep + 1).ToString();
            
    }
}
