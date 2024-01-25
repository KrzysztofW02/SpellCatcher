using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameInfo : MonoBehaviour
{
    public Player player;
    public int RoomNumber = 0;
    public TextMeshProUGUI roomLevel;
    public TextMeshProUGUI MaxHp;
    public TextMeshProUGUI MaxEnergy;
    public TextMeshProUGUI BulletPower;
    public TextMeshProUGUI PlayerLevel;
    public TextMeshProUGUI Experience;
    public TextMeshProUGUI StatPoints;
    public GameObject HPButton;
    public GameObject EnergyButton;
    public GameObject PowerButton;

    public GameObject exitButton;
    private AudioSource src;
    public AudioClip sfx1;

    private bool isButtonVisible = false;

    public void Update()
    {
        MaxHp.text = player.MaxHP.ToString();
        MaxEnergy.text = player.MaxEnergy.ToString();
        BulletPower.text = player.Power.ToString();
        PlayerLevel.text = player.Level.ToString();
        Experience.text = player.Experience.ToString();
        StatPoints.text = player.StatPoints.ToString();
        UpdateButtonVisibility();

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isButtonVisible = !isButtonVisible;

            if (isButtonVisible)
            {
                exitButton.SetActive(true);
            }
            else
            {
                exitButton.SetActive(false);
            }
        }
    }

    public void Start()
    {
        src = GameObject.FindGameObjectWithTag("SRC2").GetComponent<AudioSource>();
        src.clip = sfx1;
        src.volume = 0.7f;
        src.Play();

        Button button = HPButton.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnHPButtonClick);
        }

        Button button2 = EnergyButton.GetComponent<Button>();
        if (button2 != null)
        {
            button2.onClick.AddListener(OnEnergyButtonClick);
        }

        Button button3 = PowerButton.GetComponent<Button>();
        if (button3 != null)
        {
            button3.onClick.AddListener(OnPowerButtonClick);
        }
    }

    public void NewRoomEntered()
    {
        RoomNumber++;

        //Increase displyed room number
        roomLevel.text = "Room: " + RoomNumber.ToString();

    }

    private void UpdateButtonVisibility()
    {
        HPButton.gameObject.SetActive(player.StatPoints > 0);
        EnergyButton.gameObject.SetActive(player.StatPoints > 0);
        PowerButton.gameObject.SetActive(player.StatPoints > 0);
    }
    public void OnHPButtonClick()
    {
        if (player.StatPoints > 0)
        {
            player.MaxHP += 1;
            player.StatPoints -= 1;
        }
    }

    public void OnEnergyButtonClick()
    {
        if (player.StatPoints > 0)
        {
            player.MaxEnergy += 1;
            player.StatPoints -= 1;
        }
    }

    public void OnPowerButtonClick()
    {
        if (player.StatPoints > 0)
        {
            player.Power += 1;
            player.StatPoints -= 1;
        }
    }

    public void CloseGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
