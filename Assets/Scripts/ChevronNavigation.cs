using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChevronNavigation : MonoBehaviour
{
    public Button ChevronRb;
    public Button ChevronLb;

    public Button ChevronRb_2;
    public Button ChevronLb_2;

    public GameObject TabHUDL1;
    public GameObject TabHUDL1_P2;

    public GameObject TabHUDL2;
    public GameObject TabHUDL2_P2;

    // Start is called before the first frame update
    void Start()
    {
        ChevronRb.onClick.AddListener(ChevronR);
        ChevronLb.onClick.AddListener(ChevronL);

        ChevronRb_2.onClick.AddListener(ChevronR_2);
        ChevronLb_2.onClick.AddListener(ChevronL_2);
    }

    void ChevronR() {
        Debug.Log("ChevronR");
        TabHUDL1.SetActive(false);
        TabHUDL1_P2.SetActive(true);
    }

    void ChevronL() {
        Debug.Log("ChevronR");
        TabHUDL1.SetActive(true);
        TabHUDL1_P2.SetActive(false);
    }

    void ChevronR_2() {
        Debug.Log("ChevronR");
        TabHUDL2.SetActive(false);
        TabHUDL2_P2.SetActive(true);
    }

    void ChevronL_2() {
        Debug.Log("ChevronR");
        TabHUDL2.SetActive(true);
        TabHUDL2_P2.SetActive(false);
    }
}
