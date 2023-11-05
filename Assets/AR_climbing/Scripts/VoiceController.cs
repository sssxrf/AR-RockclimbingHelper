using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour
{

    const string LANG_CODE = "en-US";

    public float RecordingDurations = 2f;
    [SerializeField]
    Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        Setup(LANG_CODE);
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        
    }

    void Setup(string code)
    {
        SpeechToText.Instance.Setting(code);
        
    }

    public void StartListening()
    {
        SpeechToText.Instance.StartRecording("Speak any");

    }

    public void StopListening()
    {
        SpeechToText.Instance.StopRecording();

    }

    public void StartAndStop()
    {
        StartCoroutine(StartAndStopWithDelay());
    }

    private IEnumerator StartAndStopWithDelay()
    {
        StartListening();

        yield return new WaitForSeconds(RecordingDurations);

        StopListening();
    }

    public void OnFinalSpeechResult(string result)
    {
        uiText.text = "received";
        uiText.text = result;
    }


}
