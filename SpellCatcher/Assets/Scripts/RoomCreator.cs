using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RoomCreator : MonoBehaviour
{
    public GameObject EmptyRoomPrefab;
    public List<GameObject> EnemiesList = new List<GameObject>();
    private Vector3 emptyRoomPosition;
    public GameObject RoomPrefab;
    private Vector3 roomPosition;
    private Quaternion roomRotation;
    public GameObject RoomClosedPrefab;
    public static int EnemiesNumber;
    public static int LevelRoom;
    public TextMeshProUGUI roomLevel;



    void Start()
    {
        roomPosition = transform.parent.parent.position;
        switch (gameObject.tag)
        {
            case "CameraMoveRight":
                roomPosition.x += 17.8f;
                break;
            case "CameraMoveLeft":
                roomPosition.x -= 17.8f;
                break;
            case "CameraMoveTop":
                roomPosition.y += 10.0f;
                break;
            case "CameraMoveBottom":
                roomPosition.y -= 10.0f;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            emptyRoomPosition = transform.parent.parent.position;
            GameObject newRoomInstance = Instantiate(RoomPrefab, roomPosition, roomRotation);
            GameObject newEmptyRoom = Instantiate(EmptyRoomPrefab, emptyRoomPosition, roomRotation);
            GameObject newClosedRoom = Instantiate(RoomClosedPrefab, roomPosition, roomRotation);
            Transform newRoomTransform = newRoomInstance.transform;
            Destroy(transform.parent.parent.gameObject);
            AddEnemies(roomPosition);
            LevelRoom += 1;
            roomLevel.text = "Room: " + LevelRoom.ToString();
            Debug.Log("Room: " + LevelRoom);
        }
    }



    void AddEnemies(Vector2 PositionOfRoomCenter)
    {
        EnemiesNumber = Random.Range(1, 5);
        for (int i = 0; i < EnemiesNumber; i++)
        {
            GameObject enemy = EnemiesList[Random.Range(0, EnemiesList.Count)];
            Debug.Log(Random.Range(1, EnemiesList.Count) - 1);
            Vector2 SpawnPosition = PositionOfRoomCenter;
            SpawnPosition.x += (Random.Range(0, 10) - 5f);
            SpawnPosition.y += Random.Range(0f, 7f) - 3.5f;
            Instantiate(enemy, SpawnPosition, new Quaternion(0, 0, 0, 0));
        }
    }

    public int DestroyEnemy()
    {
        EnemiesNumber--;
        return EnemiesNumber;
    }

    public int NumberOfEnemies()
    {
        return EnemiesNumber;
    }
}
