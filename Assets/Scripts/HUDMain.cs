using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMain : MonoBehaviour
{
    // Very important thingies
    private GameObject HUDL_U;
    private GameObject HUDR_U;
    private GameObject HUDL_EXP;
    private GameObject HUDR_ROT;


    // Buttons
    public Button ButtonHUD1;
    public Button ButtonHUD2;
    public Button ButtonHUD3;

    public Button CounterButton;
    public Button EditNameBtn;
    public Button RotatBtn;

    // Tabs
    private GameObject Tab1;
    private GameObject Tab2;

    public Text Cityname;
    public Text PlaceholderCityname;

    public InputField CtynameInput;


    void Start()
    {
        // Find Stuff
        HUDL_U = GameObject.Find("UitklapdingL");
        Tab1 = GameObject.Find("TabHUDL1");
        Tab2 = GameObject.Find("TabHUDL2");
        HUDR_U = GameObject.Find("UitklapdingR");
        HUDL_EXP = GameObject.Find("UitklapdingExpeditions");
        HUDR_ROT = GameObject.Find("UitklapdingRotate");
        CounterButton = GameObject.Find("CounterButton").GetComponent<Button>();

        // Do some magic with HudL_U and R
        HUDL_U.SetActive(false);
        HUDR_U.SetActive(false);
        //HUDL_EXP.SetActive(false);

        // Set the button to the function
        ButtonHUD1.onClick.AddListener(ButtonHUD1_Click);
        ButtonHUD2.onClick.AddListener(ButtonHUD2_Click);
        ButtonHUD3.onClick.AddListener(ButtonHUD3_Click);
        CounterButton.onClick.AddListener(CounterButton_Click);
        RotatBtn.onClick.AddListener(RotatBtn_Click);


        // Do some other magic or sum lmfao
        Tab1.SetActive(false);
        Tab2.SetActive(false);

        Cityname.text = "Navis City";
    }

    void ButtonHUD1_Click()
    {
        HUDL_U.SetActive(!HUDL_U.activeSelf);

        Tab1.SetActive(true);
        Tab2.SetActive(false);
    }

    void ButtonHUD2_Click()
    {
        HUDL_U.SetActive(!HUDL_U.activeSelf);

        Tab1.SetActive(false);
        Tab2.SetActive(true);
    }

    void CounterButton_Click()
    {   
        if (HUDL_U.activeSelf)
        {
            HUDL_U.SetActive(false);
        } else {
            HUDR_U.SetActive(!HUDR_U.activeSelf);
        }
    }

    void ButtonHUD3_Click() {
        if (HUDL_EXP.gameObject.transform.localScale.x == 1) {
            HUDL_EXP.gameObject.transform.localScale = new Vector3(0, 0, 0);
        } else {
            HUDL_EXP.gameObject.transform.localScale = new Vector3(1, 1, 1);
        } 
    }

    void RotatBtn_Click() {
        if (HUDR_ROT.gameObject.transform.localScale.x == 1) {
            HUDR_ROT.gameObject.transform.localScale = new Vector3(0, 0, 0);
        } else {
            HUDR_ROT.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void EditNameBtn_Click()
    {
        HUDR_U.SetActive(!HUDR_U.activeSelf);
    }
}