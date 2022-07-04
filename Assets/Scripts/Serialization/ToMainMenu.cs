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

   public void Quit()
   {
      #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
      #else
         Application.Quit();
      #endif
   }

   public void LoadOptions()
   {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
      SceneManager.LoadScene(2);
   }

   public void LoadCredits()
   {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
      SceneManager.LoadScene(3);
      Debug.Log("Credits");
   }

   public void StartPleaseForTheLoveofGod()
   {
         currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
         SceneManager.LoadScene("GridScene");
   }
}
