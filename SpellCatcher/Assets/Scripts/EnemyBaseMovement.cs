using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 playerPosition;
    private GameObject playerObject;
    private Rigidbody2D RigidBody;
    public float moveSpeed = 2f;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
        }
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
            Vector2 direction = (playerPosition - RigidBody.position).normalized;
            Vector2 velocity = direction*moveSpeed;

            RigidBody.velocity = velocity;

            if(Vector2.Distance(RigidBody.position, playerPosition) < 0.1f)
            {
                RigidBody.velocity = Vector2.zero;
            }

        }
    }
}
