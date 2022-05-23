using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
   private int currentSceneIndex;

   public void LoadMainMenu()
   {
       currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
       SceneManager.LoadScene(0);
   }
}
