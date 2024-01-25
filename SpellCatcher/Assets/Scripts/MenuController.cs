using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject HowToPlayButton;
    public GameObject ExitButton;
    public GameObject CloseButton;
    public GameObject howToPlayObject;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CloseGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ShowHowToPlay()
    {
        if (howToPlayObject != null)
        {
            howToPlayObject.SetActive(true);
        }
    }

    public void HideHowToPlay()
    {
        if (howToPlayObject != null)
        {
            howToPlayObject.SetActive(false);
        }
    }
}
