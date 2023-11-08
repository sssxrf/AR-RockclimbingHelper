using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;

public class VoiceController : MonoBehaviour
{

    const string LANG_CODE = "en-US";

    public float RecordingDurations = 2f;
    public string SpeechResult = "hpsbd";

    private Camera mainCam;

    [SerializeField]
    Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        Setup(LANG_CODE);
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        mainCam = Camera.main;

        
    }

    private void ApplySpeechCheck()
    {
        IndicatorManager IM = mainCam.GetComponent<IndicatorManager>();
        ImageSelector IS = mainCam.GetComponent<ImageSelector>();

        IM.SpeechCheck(SpeechResult);
        IS.SpeechCheck(SpeechResult);
        SpeechResult = "hpsbd";
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
        yield return new WaitForSeconds(0.5f);
        ApplySpeechCheck();
    }

    public void OnFinalSpeechResult(string result)
    {
        uiText.text = "received";
        uiText.text = result;
        SpeechResult = result;
    }


}
