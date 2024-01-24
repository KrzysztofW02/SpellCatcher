using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject Player;
    private bool waiting = false;
    private GameObject Enemy;
    private Animator animator;
    private AudioSource src;
    public AudioClip sfx1;

    void Start()
    {
        Enemy = transform.parent.parent.gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = transform.parent.parent.GetComponent<Animator>();
        src = GameObject.FindGameObjectWithTag("SRC").GetComponent<AudioSource>();
    }
    void Update()
    {
        if(waiting ==false)
        {
            StartCoroutine(Firebullet());
        }
    }

    IEnumerator Firebullet()
    {
        waiting = true;
        animator.SetBool("IsShooting", true);
        Enemy.GetComponent<EnemyBaseMovement>().moveSpeed = 0;
        yield return new WaitForSeconds(1.1f);
        src.clip = sfx1;
        src.Play();
        animator.SetBool("IsShooting", false);
        Enemy.GetComponent<EnemyBaseMovement>().moveSpeed = 2;

        Vector3 playerPosition = Player.transform.position;
        playerPosition.z = 0f; 

        Vector3 shootDirection = (playerPosition - shootingPoint.position).normalized;

        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0f, 0f, angle));
        if(bullet != null)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bullet.GetComponent<EnemyBullet>().speed;
        }
        yield return new WaitForSeconds(Random.Range(2f,4f));  
        waiting = false;
    }
}
