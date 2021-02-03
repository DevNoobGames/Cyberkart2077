using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevnoobMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public Text CountDownText;
    public Rigidbody[] RBs;
    public RVP.CameraControl cameraCTRL;

    private void Start()
    {
        cameraCTRL.enabled = false;
        foreach (Rigidbody body in RBs)
        {
            body.isKinematic = true;
        }
        PauseMenu.SetActive(false);
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenu.activeInHierarchy)
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator Countdown()
    {
        CountDownText.text = "GET READY!";
        yield return new WaitForSeconds(2);
        CountDownText.text = "3";
        yield return new WaitForSeconds(1);
        CountDownText.text = "2";
        yield return new WaitForSeconds(1);
        CountDownText.text = "1";
        yield return new WaitForSeconds(1);
        CountDownText.text = "GO";
        foreach (Rigidbody body in RBs)
        {
            body.isKinematic = false;
        }
        cameraCTRL.enabled = true;
        yield return new WaitForSeconds(0.5f);
        CountDownText.text = "";
        CountDownText.enabled = false;
    }

    public void ContinuePlaying()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
