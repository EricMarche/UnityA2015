using UnityEngine;
using System.Collections;
using UltraReal.Utilities;

public class ScreenCap : Singleton {

    int _index = 0;

    [SerializeField]
    KeyCode _captureKey = KeyCode.F12;

    [SerializeField]
    string _fileTitle = "SceenGrab";

    [SerializeField]
    AudioClip _captureSound = null;

    private string OutputCaptureFileTitle
    {
        get { return _fileTitle + string.Format("{0:00}", _index) + ".png"; }
    }

    public void Start()
    {
        if (_captureSound != null) {
            if(CachedAudioSource == null)
                CachedAudioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    public void Update()
    {
        if (Input.GetKeyDown(_captureKey)){
            Application.CaptureScreenshot(OutputCaptureFileTitle);

            if (CachedAudioSource != null && _captureSound != null)
                CachedAudioSource.PlayOneShot(_captureSound);
            _index++;
        }
    }
}
