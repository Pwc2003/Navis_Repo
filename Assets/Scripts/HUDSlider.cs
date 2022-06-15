using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSlider : MonoBehaviour
{
    private GameObject[] SliderObj; 
    void Start()
    {
        SliderObj = GameObject.FindGameObjectsWithTag("Slider");
        
        foreach (GameObject slider in SliderObj)
        {
            slider.GetComponent<Slider>().enabled = false;
        }
    }
}
