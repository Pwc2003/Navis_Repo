using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTutorialPanel : MonoBehaviour
{
    private Button TutorialButtonClose;
    private GameObject TutorialPanel1;
    public Text ConfirmBtnTxt;
    void Start()
    {
        TutorialButtonClose = GameObject.Find("ButtonCL").GetComponent<Button>();
        TutorialButtonClose.onClick.AddListener(ClosePanel1);

        StartCoroutine(ButtonActivator());
    }

    void Update() {
        Timer();
        if (timeRemaining > 0) {
            ConfirmBtnTxt.text = "Understood (" + Mathf.Ceil(timeRemaining) + ")";
        } else {
            ConfirmBtnTxt.text = "Understood";
        }
    }

    void ClosePanel1() {
            Debug.Log("Tutorial Button Clicked");
            TutorialPanel1 = GameObject.Find("TUTORIAL1-Welcome");
            TutorialPanel1.SetActive(false);
    }

    private IEnumerator ButtonActivator() {
    while(true) {
        TutorialButtonClose.interactable = false;
        yield return new WaitForSeconds(5);
        TutorialButtonClose.interactable = true;
        break;
    }
}

    private float timeRemaining = 10;
    void Timer() {
        if (timeRemaining > 0 ) {
            timeRemaining -= Time.deltaTime;
            TutorialButtonClose.interactable = false;
        } else {
            TutorialButtonClose.interactable = true;
        }
    }
}
