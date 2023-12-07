using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=transform.right*speed;
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

}
