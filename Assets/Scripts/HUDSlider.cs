using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSlider : MonoBehaviour
{
    private Slider SliderObj;
    void Start()
    {
        SliderObj = GameObject.Find("Slider").GetComponent<Slider>();
        SliderObj.enabled = false;
    }
}
