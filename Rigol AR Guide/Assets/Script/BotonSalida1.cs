using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalida1 : MonoBehaviour
{
    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
