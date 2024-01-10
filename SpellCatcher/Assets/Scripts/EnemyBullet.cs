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
                player.TakeDamage(1);
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
        SpellCatcher spellCatcher =  collision.GetComponent<SpellCatcher>();

        if (spacePressed && collision.CompareTag("SpellCatcher") && spellCatcher.IsOnCooldown == false)
        {
            spellCatcher.IsUsed();


            Debug.Log("spell catched");
            Destroy(gameObject);

            if (spellCatcher != null)
            {
                spellCatcher.SpellCatched();
            }
            else
            {
                Debug.LogWarning("SpellCatcher component not found on the collided object.");
            }
        }
    }

}
