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

    private GameObject ObjectivesTab;
    private GameObject Objective1;


    // Buttons
    public Button ButtonHUD1;
    public Button ButtonHUD2;
    public Button ButtonHUD3;

    public Button CounterButton;
    public Button EditNameBtn;
    public Button RotatBtn;
    private Button MinimiseBtn;
    private Button ResetLocationsBtn;

    // Tabs
    private GameObject Tab1;
    private GameObject Tab2;

    public Text Cityname;
    public Text PlaceholderCityname;

    public InputField CtynameInput;

    Vector3 ObjectivesTabLocation;
    Vector3 HUDR_ULocation;
    Vector3 HUDL_EXPLocation;
    Vector3 HUDR_ROTLocation;



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
        ObjectivesTab = GameObject.Find("ObjectivesTAB");
        MinimiseBtn = GameObject.Find("MinimiseBtn").GetComponent<Button>();
        Objective1 = GameObject.Find("Objective1");
        ResetLocationsBtn = GameObject.Find("ResetBtn").GetComponent<Button>();

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
        MinimiseBtn.onClick.AddListener(MinimiseBtn_Click);
        ResetLocationsBtn.onClick.AddListener(ResetLocationsBtn_Click);


        // Do some other magic or sum lmfao
        Tab1.SetActive(false);
        Tab2.SetActive(false);

        Cityname.text = "Navis City";

        ObjectivesTabLocation = ObjectivesTab.gameObject.transform.localPosition;
        HUDR_ULocation = HUDR_U.gameObject.transform.localPosition;
        HUDL_EXPLocation = HUDL_EXP.gameObject.transform.localPosition;
        HUDR_ROTLocation = HUDR_ROT.gameObject.transform.localPosition;



        Debug.Log("ObjectivesTabLocation: " + ObjectivesTabLocation);
    }

    void Update() {
        if (ObjectivesTabLocation != ObjectivesTab.gameObject.transform.localPosition || HUDR_ULocation != HUDR_U.gameObject.transform.localPosition || HUDL_EXPLocation != HUDL_EXP.gameObject.transform.localPosition || HUDR_ROTLocation != HUDR_ROT.gameObject.transform.localPosition) {
            ResetLocationsBtn.gameObject.transform.localScale = new Vector3(1, 1, 1);
        } else {
            ResetLocationsBtn.gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void MinimiseBtn_Click() {
        RectTransform ObjectivesTabrt = ObjectivesTab.GetComponent<RectTransform>();

        if (ObjectivesTabrt.sizeDelta.y == 485f)
        {
            ObjectivesTabrt.sizeDelta = new Vector2(487.8538f, 175f);
            Objective1.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        }
        else
        {
            ObjectivesTabrt.sizeDelta = new Vector2(487.8538f, 485f);
            Objective1.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
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

    void ResetLocationsBtn_Click() {
        ObjectivesTab.gameObject.transform.localPosition = ObjectivesTabLocation;
        HUDR_U.gameObject.transform.localPosition = HUDR_ULocation;
        HUDL_EXP.gameObject.transform.localPosition = HUDL_EXPLocation;
        HUDR_ROT.gameObject.transform.localPosition = HUDR_ROTLocation;
    }
}