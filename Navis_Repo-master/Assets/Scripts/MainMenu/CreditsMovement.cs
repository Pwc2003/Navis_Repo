using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMovement : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime * 10, 0);
    }

    void Start()
    {
        StartCoroutine(CreditsCor());
    }

        IEnumerator CreditsCor()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene("MainMenu");
    }
}