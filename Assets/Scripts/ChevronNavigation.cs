using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChevronNavigation : MonoBehaviour
{
    public Button ChevronRb;
    public Button ChevronLb;

    public GameObject TabHUDL1;
    public GameObject TabHUDL1_P2;
    // Start is called before the first frame update
    void Start()
    {
        ChevronRb.onClick.AddListener(ChevronR);
        ChevronLb.onClick.AddListener(ChevronL);
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
}
