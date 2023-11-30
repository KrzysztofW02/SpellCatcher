using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHp = 10;
    public int EnemyHP = 10;

    private Renderer rend;
    private EnemyBaseMovement movementScript;
    private Rigidbody2D rb;
    private RoomCreator roomCreator;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();

        movementScript = GetComponent<EnemyBaseMovement>();
        roomCreator = FindObjectOfType<RoomCreator>();
    }

    public void TakeDamage(int damage)
    {
        EnemyHP -= damage;
        StartCoroutine(DamageRecived(1));
    }
    void Update()
    {
        if (EnemyHP <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
            roomCreator.DestroyEnemy();
        }
    }

    IEnumerator DamageRecived(int damageAmount)
    {
        EnemyHP -= 1;
        if(movementScript != null)
        {
            float initialSpeed = movementScript.moveSpeed;
            movementScript.moveSpeed = 0;

            yield return new WaitForSeconds(0.5f);

            movementScript.moveSpeed = initialSpeed;
        }
    }
}
