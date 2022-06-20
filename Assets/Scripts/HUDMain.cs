using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMain : MonoBehaviour
{
    // Very important thingies
    private GameObject HUDL_U;
    private GameObject HUDR_U;


    // Buttons
    public Button ButtonHUD1;
    public Button ButtonHUD2;

    public Button EditNameBtn;

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

        // Do some magic with HudL_U
        HUDL_U.SetActive(false);

        // Set the button to the function
        ButtonHUD1.onClick.AddListener(ButtonHUD1_Click);
        ButtonHUD2.onClick.AddListener(ButtonHUD2_Click);


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

    void EditNameBtn_Click()
    {
        HUDR_U.SetActive(!HUDR_U.activeSelf);
    }
}