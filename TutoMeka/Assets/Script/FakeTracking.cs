using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTracking : MonoBehaviour
{
    public GameObject uiElements;

    void Start()
    {
        Invoke("ActivateAR", 2f);
    }

    void ActivateAR()
    {
        uiElements.SetActive(true);
    }
}
