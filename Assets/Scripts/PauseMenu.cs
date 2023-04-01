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
        sfx.PlayOneShot(sfx.clip, 1);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        sfx.PlayOneShot(sfx.clip, 1);
        Application.Quit();
    }
}
