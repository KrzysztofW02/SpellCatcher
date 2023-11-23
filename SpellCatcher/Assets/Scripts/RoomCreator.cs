using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    public GameObject EmptyRoomPrefab;
    private Vector3 emptyRoomPosition;
    public GameObject RoomPrefab;
    private Vector3 roomPosition;
    private Quaternion roomRotation;

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
        Destroy(transform.parent.parent.gameObject);
    }
}
