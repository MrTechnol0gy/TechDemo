using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioSource sfx;

    void Start()
    {        
        sfx = GetComponentInChildren<AudioSource>();        
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;                            // resets the timescaling if you leave the scene from this method after getting here thorugh the pause menu
        sfx.PlayOneShot(sfx.clip, 1);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        sfx.PlayOneShot(sfx.clip, 1);
        Application.Quit();
    }
}
