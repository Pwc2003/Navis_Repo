using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTutorialPanel : MonoBehaviour
{
    private Button TutorialButtonClose;
    private GameObject TutorialPanel1;
    void Start()
    {
        TutorialButtonClose = GameObject.Find("ButtonCL").GetComponent<Button>();
        TutorialButtonClose.onClick.AddListener(ClosePanel1);
    }

    void ClosePanel1() {
            Debug.Log("Tutorial Button Clicked");
            TutorialPanel1 = GameObject.Find("TUTORIAL1-Welcome");
            TutorialPanel1.SetActive(false);
    }


}
