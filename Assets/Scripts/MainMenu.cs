using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadWonderland()
    {
        SceneManager.LoadScene("Wonderland");
    }

    public void LoadWorkshop()
    {
        SceneManager.LoadScene("Workshop");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
