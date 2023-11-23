using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera Camera;

    private Vector3 CameraPossition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Renderer renderer = other.GetComponent<Renderer>();

        if(!renderer.isVisible){
            switch (other.gameObject.tag)
            {
                case "CameraMoveRight":
                    Debug.Log("switch");
                    CameraPossition = Camera.transform.position;
                    CameraPossition.x += 17.8f;
                    Camera.transform.position = CameraPossition;
                    break;

                case "CameraMoveLeft":
                    Debug.Log("switch");
                    CameraPossition = Camera.transform.position;
                    CameraPossition.x -= 17.8f;
                    Camera.transform.position = CameraPossition;
                    break;

                case "CameraMoveTop":
                    Debug.Log("switch");
                    CameraPossition = Camera.transform.position;
                    CameraPossition.y += 10.0f;
                    Camera.transform.position = CameraPossition;
                    break;

                case "CameraMoveBottom":
                    Debug.Log("switch");
                    CameraPossition = Camera.transform.position;
                    CameraPossition.y -= 10.0f;
                    Camera.transform.position = CameraPossition;
                    break;

                default:
                    break;
            }

        }
    }
}
