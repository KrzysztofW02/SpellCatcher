using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject Background;

    public void Setup()
    {
        Background.SetActive(true);
    }

    public void RestartButton()
    {
        //Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }
}
