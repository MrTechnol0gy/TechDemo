using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponentInChildren<AudioSource>();
    }
    public void LoadWonderland()
    {        
        sfx.PlayOneShot(sfx.clip, 1);
        SceneManager.LoadScene("Wonderland");        
    }

    public void LoadWorkshop()
    {
        sfx.PlayOneShot(sfx.clip, 1);
        SceneManager.LoadScene("Workshop");
    }

    public void QuitGame()
    {
        sfx.PlayOneShot(sfx.clip, 1);
        Application.Quit();        
    }
}
