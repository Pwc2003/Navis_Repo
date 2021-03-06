using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private int currentSceneIndex;

    public Button ApplyBtn;


    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        ApplyBtn.onClick.AddListener(ApplySettings);
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("musicvolume", musicVolume);
    }

    public void SetSfxVolume(float sfxVolume)
    {
        audioMixer.SetFloat("sfxvolume", sfxVolume);
    }

    public void SetQuality(int qualityIndex) 
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    void Update()
    {
        // DEZE SHIT STAAT OOK IN APPLY SETITNGS XXXX
        //if(Input.GetKeyDown(KeyCode.Return))
        //{
        //    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //    PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        //    SceneManager.LoadScene(0);
        //}
    }

    public void ApplySettings() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(1);
    }
}
