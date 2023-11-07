using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class IndicatorManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Indicator;

    

    [SerializeField]
    private LayerMask layersToInclude;

    // Update is called once per frame
    void Update()
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
                    GameObject newObject = GameObject.Instantiate(Indicator, hit.point, newObjectRotation);
                    newObject.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
                }
            }
        }

        
    }
}
