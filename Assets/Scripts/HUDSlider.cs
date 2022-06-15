using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSlider : MonoBehaviour
{
    private GameObject[] SliderObj; 
    private Slider Slider;
    private int SliderValue;
    private Text SliderText;
    void Start()
    {
        SliderObj = GameObject.FindGameObjectsWithTag("Slider");
        
        foreach (GameObject slider in SliderObj)
        {
            slider.GetComponent<Slider>().enabled = false;

            Slider = slider.GetComponent<Slider>();

            Debug.Log("Slider found & disabled");
        }
    }
}
