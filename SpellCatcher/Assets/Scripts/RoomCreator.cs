using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RoomCreator : MonoBehaviour
{
    public GameObject EmptyRoomPrefab;
    public GameObject CratePrefab;
    public List<GameObject> EnemiesList = new List<GameObject>();
    private Vector3 emptyRoomPosition;
    public GameObject RoomPrefab;
    private Vector3 roomPosition;
    private Quaternion roomRotation;
    public GameObject RoomClosedPrefab;
    public static int EnemiesNumber;


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

            //Adding crates to room
            for (int i = 0; i < 4; i++)
            {
                //Create first crate
                Vector2 FirstCratePosition = roomPosition;
                FirstCratePosition.x += (Random.Range(0, 10) - 5f);
                FirstCratePosition.y += Random.Range(0, 7) - 3.5f;
                Instantiate(CratePrefab, FirstCratePosition, new Quaternion(0, 0, 0, 0));

                //Create more crates adjacent to first crate
                Vector2 CratePosition = FirstCratePosition;
                while (Random.Range(0, 10) < 5)
                {
                    //Chech if crate is not in the wall
                    if(CratePosition.x < roomPosition.x - 7.5f || CratePosition.x > roomPosition.x + 7.5f || CratePosition.y < roomPosition.y - 3.5f || CratePosition.y > roomPosition.y + 3.5f)
                    {
                        continue;
                    }
                    int[] upOrDown = {-1,1};
                    CratePosition.x += upOrDown[Random.Range(0, 2)];
                    CratePosition.y += upOrDown[Random.Range(0, 2)];
                    Instantiate(CratePrefab, CratePosition, new Quaternion(0, 0, 0, 0));
                }
            }

            AddEnemies(roomPosition);

            GameObject.FindWithTag("GameController").GetComponent<GameInfo>().NewRoomEntered();
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
