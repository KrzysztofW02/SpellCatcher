using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    public float movementSpeed = 10.0f;

    private float movementX;
    private float movementY;

    void Start()
    {
        
    }

    void OnMove(InputValue inputValue){
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        var currentPossition = transform.position;
        currentPossition.x += (movementX/100) * movementSpeed;
        currentPossition.y += (movementY/100) * movementSpeed;
        transform.position = currentPossition;
    }

}
