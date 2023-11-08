using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject IndicatorOrange;
    public GameObject IndicatorGreen;
    public GameObject IndicatorYellow;
    private GameObject VoiceControl;

    public bool DrawPathByHand = true;
    public bool notDisplayed = true;

    public string MapImage = "YellowMap";

    [SerializeField]
    private LayerMask layersToInclude;

    private Vector3 PathStartPosition;

    private List<GameObject> OrangePath = new List<GameObject>();
    private List<GameObject> GreenPath = new List<GameObject>();
    private List<GameObject> YellowPath = new List<GameObject>();

    private string OrangeMap = "OrangeMap";
    private string GreenMap = "GreenMap";
    private string YellowMap = "YellowMap";

    

    void Start()
    {

        
    }

    public void SpeechCheck(string SpeechContent)
    {
        
        if (SpeechContent == "Show path" || SpeechContent == "Show pass")
        {

            DisplayCurrentPath();

        }
        else if (SpeechContent == "Generate new path" || SpeechContent == "Generate new pass")
        {
            DisplayTwoOtherPath();
        }
        else if (SpeechContent == "Choose green path" || SpeechContent == "Choose green pass")
        {
            KeepGreenPath();
        }
        else if (SpeechContent == "Choose orange path" || SpeechContent == "Choose orange path")
        {
            KeepOrangePath();
        }
    }

    // Update is called once per frame
    void Update()
    {
        





        if (DrawPathByHand)
        {

            for(int i =0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);
                var touchPhase = touch.phase;

                if(touchPhase == TouchPhase.Began || touchPhase == TouchPhase.Moved)
                {
                
                    var ray = GetComponent<Camera>().ScreenPointToRay(touch.position);

                    var hasHit = Physics.Raycast(ray, out var hit, float.PositiveInfinity, layersToInclude);

                    if (hasHit)
                    {
                    
                        Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                        GameObject newObject = GameObject.Instantiate(IndicatorOrange, hit.point, newObjectRotation);
                        newObject.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                    }
                }
            }

        }
        else
        {
            if (notDisplayed)
            {

                DisplayCurrentPath();
                notDisplayed = false;

            }
        }

        

        
    }

    public void ToggleDrawGenerate()
    {
        if (DrawPathByHand)
        {
            DrawPathByHand = false;
            notDisplayed = true;
        }
        else
        {
            DrawPathByHand = true;
        }
    }

    private void DisplayCurrentPath()
    {
        var MainCam = GetComponent<Camera>();
        var screenCenter = MainCam.ViewportPointToRay(new Vector3(0.5f,0.5f, 0));
        var StarthasHit = Physics.Raycast(screenCenter, out var starthit, float.PositiveInfinity, layersToInclude);

        if (StarthasHit)
        {
            PathStartPosition = starthit.point;
            int numIndicatorInPath = 500;
            float spacing = 0.002f;

            for (int i = 0; i<numIndicatorInPath; i++)
            {
                Vector3 pathPosition = PathStartPosition + Vector3.up * i * spacing + Vector3.left * Random.Range(-0.001f,0.001f);
                Vector3 screenPoint = MainCam.WorldToScreenPoint(pathPosition);
                var newRay = MainCam.ScreenPointToRay(screenPoint);

                var hasHit = Physics.Raycast(newRay, out var hit, float.PositiveInfinity, layersToInclude);
                if (hasHit)
                {

                    Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    GameObject newObject = GameObject.Instantiate(IndicatorYellow, hit.point, newObjectRotation);
                    newObject.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                    YellowPath.Add(newObject);
                }

            }
        }
        MapImage = YellowMap;
    }

    public void DisplayTwoOtherPath()
    {
        var MainCam = GetComponent<Camera>();
        
        
        int numIndicatorInPath = 500;
        float spacing = 0.002f;

        for (int i = 0; i < numIndicatorInPath; i++)
        {
            Vector3 pathPositionGreen = PathStartPosition + Vector3.up * i * spacing + Vector3.left * i *Random.Range(-0.003f, -0.0028f);
            Vector3 screenPointGreen = MainCam.WorldToScreenPoint(pathPositionGreen);
            var newRayGreen = MainCam.ScreenPointToRay(screenPointGreen);

            var hasHitG = Physics.Raycast(newRayGreen, out var hitG, float.PositiveInfinity, layersToInclude);
            if (hasHitG)
            {

                Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hitG.normal);
                GameObject newObjectG = GameObject.Instantiate(IndicatorGreen, hitG.point, newObjectRotation);
                newObjectG.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                GreenPath.Add(newObjectG);
            }

            Vector3 pathPositionOrange = PathStartPosition + Vector3.up * i * spacing + Vector3.left * i * Random.Range(0.0028f, 0.003f);
            Vector3 screenPointOrange = MainCam.WorldToScreenPoint(pathPositionOrange);
            var newRayOrange = MainCam.ScreenPointToRay(screenPointOrange);

            var hasHitO = Physics.Raycast(newRayOrange, out var hitO, float.PositiveInfinity, layersToInclude);
            if (hasHitO)
            {

                Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hitO.normal);
                GameObject newObjectY = GameObject.Instantiate(IndicatorOrange, hitO.point, newObjectRotation);
                newObjectY.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                YellowPath.Add(newObjectY);
            }

        }
        
    }

    public void KeepGreenPath()
    {
        DestroyPath(OrangePath);
        DestroyPath(YellowPath);
        MapImage = GreenMap;

    }

    public void KeepOrangePath()
    {
        DestroyPath(YellowPath);
        DestroyPath(GreenPath);
        MapImage = OrangeMap;
    }

    private void DestroyPath(List<GameObject> pathToDestroy)
    {
        foreach(GameObject obj in pathToDestroy)
        {
            Destroy(obj);
        }
    }

}
