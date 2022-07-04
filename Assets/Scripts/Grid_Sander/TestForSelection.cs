using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForSelection : MonoBehaviour
{
    public bool selected = false;

    void Update()
    {
        if(selected)
        {
            tag = "SelectedObject";
        }
        else if(!selected && tag == "SelectedObject")
        {
            tag = "PlacedObject";
        }
    }
}
