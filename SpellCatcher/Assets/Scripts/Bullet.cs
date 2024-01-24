using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    private Rigidbody2D rb;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=transform.right*speed;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyBase enemy = collision.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage * player.Power);
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall") || collision.CompareTag("CameraMoveRight") || collision.CompareTag("CameraMoveLeft") || collision.CompareTag("CameraMoveTop") || collision.CompareTag("CameraMoveBottom"))
        {
            Destroy(gameObject);
        }
    }

}
