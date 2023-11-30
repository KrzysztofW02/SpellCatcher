using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    public GameObject EmptyRoomPrefab;
    public List<GameObject> EnemiesList = new List<GameObject>();
    private Vector3 emptyRoomPosition;
    public GameObject RoomPrefab;
    private Vector3 roomPosition;
    private Quaternion roomRotation;

    private int enemiesNumber;
    private GameObject newEmptyRoom2;

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
        emptyRoomPosition = transform.parent.parent.position;
        GameObject newRoomInstance = Instantiate(RoomPrefab, roomPosition, roomRotation);
        GameObject newEmptyRoom = Instantiate(EmptyRoomPrefab, emptyRoomPosition, roomRotation);
        newEmptyRoom2 = Instantiate(EmptyRoomPrefab, roomPosition, roomRotation);
        newEmptyRoom.transform.parent = newRoomInstance.transform;
        Destroy(transform.parent.parent.gameObject);
        enemiesNumber = AddEnemies(roomPosition);
    }


    int AddEnemies(Vector2 PositionOfRoomCenter)
    {
        int EnemiesNumber = Random.Range(1, 5);
        for (int i = 0; i < EnemiesNumber; i++)
        {
            GameObject enemy = EnemiesList[Random.Range(0, EnemiesList.Count)];
            Debug.Log(Random.Range(1, EnemiesList.Count) - 1);
            Vector2 SpawnPosition = PositionOfRoomCenter;
            SpawnPosition.x += (Random.Range(0, 10) - 5f);
            SpawnPosition.y += Random.Range(0f, 7f) - 3.5f;
            Instantiate(enemy, SpawnPosition, new Quaternion(0, 0, 0, 0));
        }
        return EnemiesNumber;
    }

    void Update()
    {
        if (enemiesNumber <= 0)
        {
            Destroy(newEmptyRoom2);
        }
    }
}
