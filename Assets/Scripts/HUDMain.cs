using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMain : MonoBehaviour
{
    // Very important thingies
    private GameObject HUDL_U;


    // Buttons
    public Button ButtonHUD1;
    public Button ButtonHUD2;

    public Button EditNameBtn;

    // Tabs
    private GameObject Tab1;
    private GameObject Tab2;

    public Text Cityname;


    void Start()
    {
        // Find Stuff
        HUDL_U = GameObject.Find("Uitklapding");
        Tab1 = GameObject.Find("TabHUDL1");
        Tab2 = GameObject.Find("TabHUDL2");

        // Do some magic with HudL_U
        HUDL_U.SetActive(false);

        // Set the button to the function
        ButtonHUD1.onClick.AddListener(ButtonHUD1_Click);
        ButtonHUD2.onClick.AddListener(ButtonHUD2_Click);

        EditNameBtn.onClick.AddListener(EditNameBtn_Click);

        // Do some other magic or sum lmfao
        Tab1.SetActive(false);
        Tab2.SetActive(false);
    }

    void ButtonHUD1_Click()
    {
        //Tab1.SetActive(!Tab1.activeSelf);
        HUDL_U.SetActive(!HUDL_U.activeSelf);

        Tab1.SetActive(true);
        Tab2.SetActive(false);
    }

    void ButtonHUD2_Click()
    {
        //Tab2.SetActive(!Tab2.activeSelf);
        HUDL_U.SetActive(!HUDL_U.activeSelf);

        Tab1.SetActive(false);
        Tab2.SetActive(true);
    }

    void EditNameBtn_Click()
    {
        if (Cityname.text == "Navis City")
        {
            Cityname.text = "Cheese City";
        } else {
            Cityname.text = "Navis City";
        }
    }
}
