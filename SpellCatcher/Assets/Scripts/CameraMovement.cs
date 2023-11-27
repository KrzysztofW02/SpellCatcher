using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera Camera;
    public float TransitionTime = 1f;

    private Vector3 CameraPosition;
    private bool isTransitioning = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        Renderer renderer = other.GetComponent<Renderer>();

        if (!renderer.isVisible && !isTransitioning)
        {
            MoveCamera(other.gameObject.tag);
        }
    }

    void MoveCamera(string direction)
    {
        isTransitioning = true;

        CameraPosition = Camera.transform.position;

        switch (direction)
        {
            case "CameraMoveRight":
                CameraPosition.x += 17.8f;
                break;
            case "CameraMoveLeft":
                CameraPosition.x -= 17.8f;
                break;
            case "CameraMoveTop":
                CameraPosition.y += 10.0f;
                break;
            case "CameraMoveBottom":
                CameraPosition.y -= 10.0f;
                break;
            default:
                break;
        }

        StartCoroutine(TransitionCamera());
    }

    IEnumerator TransitionCamera()
    {
        float elapsedTime = 0.75f;
        Vector3 startPosition = Camera.transform.position;

        while (elapsedTime < TransitionTime)
        {
            Camera.transform.position = Vector3.Lerp(startPosition, CameraPosition, elapsedTime / TransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Camera.transform.position = CameraPosition;
        isTransitioning = false;
    }
}
