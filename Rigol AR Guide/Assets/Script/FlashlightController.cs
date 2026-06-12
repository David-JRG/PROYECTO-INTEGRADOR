using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    private bool flashOn = false;

    AndroidJavaObject cameraManager;
    string cameraId;

    [Header("UI")]
    public Image flashButtonImage;

    public Sprite flashOffSprite;
    public Sprite flashOnSprite;

    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR

        AndroidJavaClass unityPlayer =
            new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject currentActivity =
            unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        cameraManager =
            currentActivity.Call<AndroidJavaObject>(
                "getSystemService",
                "camera"
            );

        cameraId =
            cameraManager.Call<string[]>("getCameraIdList")[0];

#endif

        UpdateButtonVisual();
    }

    public void ToggleFlash()
    {
        flashOn = !flashOn;

#if UNITY_ANDROID && !UNITY_EDITOR

        cameraManager.Call(
            "setTorchMode",
            cameraId,
            flashOn
        );

#endif

        UpdateButtonVisual();
    }

    void UpdateButtonVisual()
    {
        if (flashOn)
        {
            flashButtonImage.sprite = flashOnSprite;
        }
        else
        {
            flashButtonImage.sprite = flashOffSprite;
        }
    }

    private void OnApplicationPause(bool pause)
    {
#if UNITY_ANDROID && !UNITY_EDITOR

        if (pause && flashOn)
        {
            cameraManager.Call(
                "setTorchMode",
                cameraId,
                false
            );

            flashOn = false;

            UpdateButtonVisual();
        }

#endif
    }
}
