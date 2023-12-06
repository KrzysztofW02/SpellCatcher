using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedRoom : MonoBehaviour
{
    private RoomCreator roomCreator;
    // Start is called before the first frame update
    void Start()
    {
        roomCreator = FindObjectOfType<RoomCreator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roomCreator != null && roomCreator.NumberOfEnemies() == 0)
        {
            Destroy(gameObject);
        }

    }
}
