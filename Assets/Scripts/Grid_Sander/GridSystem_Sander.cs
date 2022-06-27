using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem_Sander : MonoBehaviour
{
    public GameObject snapPoint;
    private GameObject snapPointInList;

    private int rowSize = 20;

    private float newPositionX;
    private float newPositionY;
    private float newPositionZ;

    [HideInInspector]public List<GameObject> snapPoints;

    private Vector3 snapPosition = new Vector3(10f, 0f, 10f);
    private Vector3 change =  new Vector3(0f, 0f, 20f);


    // Start is called before the first frame update
    void Start()
    {
        snapPoints = new List<GameObject>();
        for(int i = 0; i <= 20; i++)
        {
            for(int j = 0; j <= 20; j++)
            {
                snapPointInList = Instantiate(snapPoint, snapPosition + j * change, Quaternion.identity);
                snapPoints.Add(snapPointInList);
            }
            snapPosition += new Vector3(20f, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
