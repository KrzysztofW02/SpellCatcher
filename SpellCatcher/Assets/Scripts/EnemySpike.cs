using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    public int damage;
    public float damageInterval = 1f;
    public float detectionRadius = 1.5f;
    public LayerMask playerLayer; 

    private void Start()
    {
        InvokeRepeating("DealDamageToPlayer", 0f, damageInterval);
    }

    private void DealDamageToPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Player player = collider.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }
        }
    }
}
