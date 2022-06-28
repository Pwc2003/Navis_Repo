using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expedition : MonoBehaviour
{
    public Button BuyBtn;
    public Button CancelBtn;
    public GameObject Progressbar;
    private bool Progressing;
    private bool FailCheck = true;

    public Text ExpeditionStatus;
    public Text CostPrice;

    private float num;
    private float num2;

    [Range(0.0f, 1f)] public float Speed;
    [Range(0.0f, 1f)] public float Chance_of_Failure;

    public Image progressbarimg;
    void Start()
    {
        BuyBtn.onClick.AddListener(BuyBtn_Click);
        CancelBtn.onClick.AddListener(CancelBtn_Click);

        num = Random.Range(0.5f, 0.99f);
        num2 = num + 0.1f;

        CancelBtn.gameObject.SetActive(false);
    }

    void BuyBtn_Click() {
        Debug.Log("BuyBtn_Click");
        CancelBtn.gameObject.SetActive(true);
        Progressing = true;
    }

    void Update() {
        if (Progressing) {
            if (Progressbar.gameObject.transform.localScale.x < 1) {

            if (Progressbar.gameObject.transform.localScale.x > num && Progressbar.gameObject.transform.localScale.x < num2 && FailCheck) {
                //float percentChance = Chance_of_Failure;
                if (Random.value <= Chance_of_Failure) {
                    Debug.Log("Fail");
                    progressbarimg.color = new Color(255f, 0f, 0f, 0.3f);
                    ExpeditionStatus.text = "Expedition failed";
                    CostPrice.text = "Everything was lost";
                    Debug.Log("Random.value: " + Random.value);
                    CancelBtn.gameObject.SetActive(false);


                    Progressing = false;
                    FailCheck = false;

                    return;
                } else {
                    Debug.Log("Success");
                    FailCheck = false;
                }
            }

            ExpeditionStatus.text = "Expedition in progress";
            CostPrice.text = (int)(Progressbar.gameObject.transform.localScale.x * 100) + "% complete";

            Progressbar.gameObject.transform.localScale += new Vector3(0.1f, 0f, 0f) * Time.deltaTime * Speed;
            BuyBtn.interactable = false;
            } else if (Progressbar.gameObject.transform.localScale.x >= 1) {
                Progressing = false;
                Progressbar.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                ExpeditionStatus.text = "Expedition complete";
                CostPrice.text = "Succesfully completed";
                CancelBtn.gameObject.SetActive(false);
            }
        } else if (!Progressing) {
            if (Progressbar.gameObject.transform.localScale.x >= 0f) {
            Progressbar.gameObject.transform.localScale += new Vector3(-0.1f, 0f, 0f) * Time.deltaTime * 0.05f;
            }
            if (Progressbar.gameObject.transform.localScale.x <= 0f) {
                Progressbar.gameObject.transform.localScale = new Vector3(0f, 1f, 1f);
                BuyBtn.interactable = true;
                ExpeditionStatus.text = "Start expedition";
                CostPrice.text = "Costs: Citizens, Food, Water";
                CancelBtn.gameObject.SetActive(false);
                progressbarimg.color = new Color(0.4316483f, 0.9433962f, 0.5404651f, 0.3921569f);
                FailCheck = true;
            }
        }
    }

    void CancelBtn_Click() {
        Progressing = false;
        ExpeditionStatus.text = "Expedition cancelled";
        CostPrice.text = "Returning...";
        CancelBtn.gameObject.SetActive(false);
    }
}
