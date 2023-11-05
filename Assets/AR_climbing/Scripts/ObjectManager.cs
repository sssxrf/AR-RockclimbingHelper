using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectManager : MonoBehaviour
{
    public ARSession aRSession;
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
        GameObject TrackedObjects = GameObject.Find("Trackables");
        if (TrackedObjects != null)
        {
            foreach (Transform child in TrackedObjects.transform)
            {
                //string childName = child.name.Substring(0, Mathf.Min(4, child.name.Length));
                //if (childName == "Mani")
                //{
                //    
                //}
                Destroy(child.gameObject);


            }
            //StartCoroutine(DestroyAndAccess(TrackedObjects.transform));
        }
        else
        {
            Debug.Log("GameObject not found");
        }
        aRSession.Reset();
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
