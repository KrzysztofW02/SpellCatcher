using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    public int damage;
    public float damageInterval = 1f;
    public float detectionRadius = 1.5f;
    public LayerMask playerLayer; 
    private Animator animator;
    private AudioSource src;
    public AudioClip sfx1;

    private void Start()
    {
        InvokeRepeating("DealDamageToPlayer", 0f, damageInterval);
        animator = GetComponentInParent<Animator>();
        src = GameObject.FindGameObjectWithTag("SRC").GetComponent<AudioSource>();
    }

    private void DealDamageToPlayer()
    {
        StartCoroutine(Attack());
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, playerLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Player player = collider.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                    src.clip = sfx1;
                    src.Play();
                }
            }
        }
    }
    private IEnumerator Attack()
    {
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(0.87f);
        animator.SetBool("IsAttacking", false);
    }
}
