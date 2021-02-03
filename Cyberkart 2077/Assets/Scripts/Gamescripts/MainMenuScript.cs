using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
