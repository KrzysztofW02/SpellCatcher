using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfo : MonoBehaviour
{
    public int RoomNumber = 0;
    public TextMeshProUGUI roomLevel;

    public void NewRoomEntered()
    {
        RoomNumber++;

        //Increase displyed room number
        roomLevel.text = "Room: " + RoomNumber.ToString();

    }

}
