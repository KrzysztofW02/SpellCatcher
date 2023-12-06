using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHp;
    public int EnemyHP;

    private Renderer rend;
    private EnemyBaseMovement movementScript;
    private Rigidbody2D rb;
    private RoomCreator roomCreator;
    void Start()
    {
        EnemyMaxHp = 10;
        EnemyHP = EnemyMaxHp;
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
            Destroy(gameObject);
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
