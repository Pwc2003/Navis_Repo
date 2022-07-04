using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildIDShower : MonoBehaviour
{
    public Text BuildID;
    void Start()
    {
        BuildID.text = "VERSION " + Application.version;
    }
}
