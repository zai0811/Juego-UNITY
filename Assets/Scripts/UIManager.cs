using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public AudioSource clip;
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void AnotherOptions()
    {
        //sounds
        //graphics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }                           

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
