using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu00Controller : MonoBehaviour 
{
    public void Play()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("menu00");
    }
}