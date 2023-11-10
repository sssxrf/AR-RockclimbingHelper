using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Delete3DRock : MonoBehaviour
{

    private GameObject Descrip;
    private bool ObjectFound = false;
    public GameObject Mountain;

    public ARSession aRSession;
    // public GameObject 3D_Mountain;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!ObjectFound){
            Descrip = GameObject.FindWithTag("MikeRock");
            if (Descrip != null){
                Descrip.SetActive(false);
                ObjectFound = true;
            }
        }
    }

    public void DeleteTrackableObject()
    {
        GameObject PlacedModel = GameObject.Find("PlaceableMountains(Clone)");
        if (PlacedModel != null)
        {
            Destroy(PlacedModel);
        }
    }

    public void SetVisibleDescription(){
        Descrip.SetActive(true);
    }
}
