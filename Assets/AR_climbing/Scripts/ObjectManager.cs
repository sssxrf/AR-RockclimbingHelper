using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectManager : MonoBehaviour
{
    public ARSession aRSession;

    public GameObject Full_route;
    public GameObject Yellow_route;

    public GameObject ARObject;
   
    // Start is called before the first frame update
    void Start()
    {

        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteAllTrackableObjects()
    {
        //GameObject TrackedObjects = GameObject.Find("Trackables");
        //if (TrackedObjects != null)
        //{
        //    foreach (Transform child in TrackedObjects.transform)
        //    {
        //        //string childName = child.name.Substring(0, Mathf.Min(4, child.name.Length));
        //        //if (child.name == "PlaceableRaw(Clone)")
        //        //{

        //        //}

        //        Destroy(child.gameObject);

        //    }
        //    //StartCoroutine(DestroyAndAccess(TrackedObjects.transform));
        //}
        //else
        //{
        //    Debug.Log("GameObject not found");
        //}

        GameObject PlacedModel = GameObject.Find("PlaceableRaw(Clone)");
        if (PlacedModel != null)
        {
            Destroy(PlacedModel);
        }
        //aRSession.Reset();
    }

    public void ReplaceCurrentObject()
    {
        GameObject PlacedModel = GameObject.Find("PlaceableRaw(Clone)");
        if (PlacedModel != null)
        {

            Transform currentTrans = PlacedModel.transform;
            Transform currentParentTrans = PlacedModel.transform.parent;



            GameObject PlaceableFull = Instantiate(Full_route, currentTrans.position, currentTrans.rotation);
            PlaceableFull.transform.localScale = currentTrans.localScale;
            if (currentParentTrans != null)
            {
                PlaceableFull.transform.SetParent(currentParentTrans);
            }
            Destroy(PlacedModel);
        }
        
        
    }

    public void ReplaceWithYellow()
    {
        GameObject PlacedModel = GameObject.Find("PlaceableFull(Clone)");
        if (PlacedModel != null)
        {

            Transform currentTrans = PlacedModel.transform;
            Transform currentParentTrans = PlacedModel.transform.parent;



            GameObject PlaceableFull = Instantiate(Yellow_route, currentTrans.position, currentTrans.rotation);
            PlaceableFull.transform.localScale = currentTrans.localScale;
            if (currentParentTrans != null)
            {
                PlaceableFull.transform.SetParent(currentParentTrans);
            }
            Destroy(PlacedModel);
        }
    }

    //private IEnumerator DestroyAndAccess(Transform parent)
    //{
    //    foreach (Transform child in parent)
    //    {
    //        Destroy(child.gameObject);
    //        yield return new WaitForSeconds(0.01f);
    //    }
    //    // Delay for one frame to ensure that the child objects have been destroyed.
    //    yield return null;

    //}



}
