using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControlScript : MonoBehaviour
{
    public static MusicControlScript instance;

    public void Awake() {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "GridScene") {
        Destroy(this.gameObject);
        }
    }

}
