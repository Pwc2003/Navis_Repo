using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem_Sander : MonoBehaviour
{
    public GameObject snapPoint;
    private GameObject snapPointInList;
    private GameObject plane;

    public GameObject check;

    private int cellAmount = 50;

    private float newPositionX;
    private float newPositionY;
    private float newPositionZ;

    [HideInInspector]public List<GameObject> snapPoints;
    [HideInInspector]public List<GameObject> availableSnapPoints;
    [HideInInspector]public List<GameObject> removedSnapPoints;

    private Vector3 snapPosition = new Vector3(10f, 0f, 10f);
    private Vector3 change =  new Vector3(0f, 0f, 20f);
    private Vector3 renderRange;

    // Justin's bullcrap

    public Material GroundMat;


    // Start is called before the first frame update
    void Start()
    {
        snapPoints = new List<GameObject>();
        removedSnapPoints = new List<GameObject>();
        for(int i = 0; i <= cellAmount; i++)
        {
            for(int j = 0; j <= cellAmount; j++)
            {
                snapPointInList = Instantiate(snapPoint, snapPosition + j * change, Quaternion.identity);
                snapPoints.Add(snapPointInList);
                snapPointInList.transform.GetChild(0).GetComponent<Renderer>().material = GroundMat;
                availableSnapPoints.Add(snapPointInList);
            }
            snapPosition += new Vector3(20f, 0f, 0f);
        }
    }
    private void Update()
    {
    }
}
