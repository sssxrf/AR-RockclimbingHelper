using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManger : MonoBehaviour
{
    private List<Vector3> positionList;
    private GameObject Arrow;
    private int currentIndex = 0;
    

    private void Start()
    {

        


    }
    public void ShowArrow()
    {
        Arrow = GameObject.FindWithTag("Arrow");
        Arrow.SetActive(true);
    }

    public void MoveArrowToNext()
    {
        
        positionList.Add(new Vector3(-0.13f, 0, 0));
        positionList.Add(new Vector3(-0.13f, 0, 0));
        positionList.Add(new Vector3(0.26f, 0, 0));

        Arrow = GameObject.FindWithTag("Arrow");
        Arrow.transform.position = Arrow.transform.position + positionList[currentIndex];

        currentIndex++;

        if(currentIndex >= positionList.Count)
        {
            currentIndex = 0;
        }
    }
}
