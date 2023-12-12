using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private bool spacePressed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=transform.right*speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(5);
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall") || collision.CompareTag("CameraMoveRight") || collision.CompareTag("CameraMoveLeft") || collision.CompareTag("CameraMoveTop") || collision.CompareTag("CameraMoveBottom"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spacePressed && collision.CompareTag("SpellCatcher"))
        {
            Debug.Log("spell catched");
            Destroy(gameObject);
        }
    }

}
