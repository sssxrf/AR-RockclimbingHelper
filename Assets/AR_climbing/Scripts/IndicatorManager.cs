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

    public bool DrawPathByHand = true;
    public bool notDisplayed = true;

    [SerializeField]
    private LayerMask layersToInclude;

    private Vector3 PathStartPosition;

    private List<GameObject> OrangePath = new List<GameObject>();
    private List<GameObject> GreenPath = new List<GameObject>();
    private List<GameObject> YellowPath = new List<GameObject>();


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
                    GameObject newObject = GameObject.Instantiate(IndicatorOrange, hit.point, newObjectRotation);
                    newObject.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                    OrangePath.Add(newObject);
                }

            }
        }
    }

    public void DisplayTwoOtherPath()
    {
        var MainCam = GetComponent<Camera>();
        
        
        int numIndicatorInPath = 500;
        float spacing = 0.002f;

        for (int i = 0; i < numIndicatorInPath; i++)
        {
            Vector3 pathPositionGreen = PathStartPosition + Vector3.up * i * spacing + Vector3.left * i *Random.Range(-0.003f, -0.002f);
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

            Vector3 pathPositionYellow = PathStartPosition + Vector3.up * i * spacing + Vector3.left * i * Random.Range(0.002f, 0.003f);
            Vector3 screenPointYellow = MainCam.WorldToScreenPoint(pathPositionYellow);
            var newRayYellow = MainCam.ScreenPointToRay(screenPointYellow);

            var hasHitY = Physics.Raycast(newRayYellow, out var hitY, float.PositiveInfinity, layersToInclude);
            if (hasHitY)
            {

                Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hitY.normal);
                GameObject newObjectY = GameObject.Instantiate(IndicatorYellow, hitY.point, newObjectRotation);
                newObjectY.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                YellowPath.Add(newObjectY);
            }

        }
        
    }

    public void KeepGreenPath()
    {
        DestroyPath(OrangePath);
        DestroyPath(YellowPath);

    }

    public void KeepYellowPath()
    {
        DestroyPath(OrangePath);
        DestroyPath(GreenPath);

    }

    private void DestroyPath(List<GameObject> pathToDestroy)
    {
        foreach(GameObject obj in pathToDestroy)
        {
            Destroy(obj);
        }
    }

}
