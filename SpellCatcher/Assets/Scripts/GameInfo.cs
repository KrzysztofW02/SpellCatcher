using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

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

    public void Update()
    {
        MaxHp.text = player.MaxHP.ToString();
        MaxEnergy.text = player.MaxEnergy.ToString();
        BulletPower.text = player.Power.ToString();
        PlayerLevel.text = player.Level.ToString();
        Experience.text = player.Experience.ToString();
        StatPoints.text = player.StatPoints.ToString();
    }

    public void Start()
    {
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

}
