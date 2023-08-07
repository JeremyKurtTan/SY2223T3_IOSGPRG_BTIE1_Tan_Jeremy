using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStuff : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Surviv.io");
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Restart");
    }
}
