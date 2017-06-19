using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu01Controller : MonoBehaviour 
{
    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }
}