using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToWake : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreditsCor());
    }

        IEnumerator CreditsCor()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");
    }
}
