using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public static ButtonSound Instance;

    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
