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
    void Start()
    {
        EnemyMaxHp = 15;
        EnemyHP = EnemyMaxHp;
        StartCoroutine(ExecuteFunctionEverySecond());
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();

        movementScript = GetComponent<EnemyBaseMovement>();
    }

    IEnumerator ExecuteFunctionEverySecond()
    {
        while (true)
        {
            StartCoroutine(DamageRecived(1));
            yield return new WaitForSeconds(1.0f);
        }
    }
    void Update()
    {
        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DamageRecived(int damageAmount)
    {
        EnemyHP -= 1;
        if(movementScript != null)
        {
            float initialSpeed = movementScript.moveSpeed;
            movementScript.moveSpeed = 0;

            yield return new WaitForSeconds(0.3f);

            movementScript.moveSpeed = initialSpeed;
        }
    }
}
