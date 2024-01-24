using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHp = 10;
    public int EnemyHP;
    public GameObject MedKit;
    public int MedKitDropChance;

    private Renderer rend;
    private EnemyBaseMovement movementScript;
    private Rigidbody2D rb;
    private RoomCreator roomCreator;
    private GameObject player;
    private int roomNumber;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        roomNumber = GameObject.FindWithTag("GameController").GetComponent<GameInfo>().RoomNumber;
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        EnemyMaxHp += roomNumber;
        EnemyHP = EnemyMaxHp;

        movementScript = GetComponent<EnemyBaseMovement>();
        roomCreator = FindObjectOfType<RoomCreator>();
    }

    public void TakeDamage(int damage)
    {
        EnemyHP -= damage;
        StartCoroutine(DamageRecived());
    }
    void Update()
    {
        if (EnemyHP <= 0)
        {
            //Give player EXP
            player.GetComponent<Player>().AddExperience(5*roomNumber);

            if(Random.Range(0,100)<MedKitDropChance)
                Instantiate(MedKit, transform.position, Quaternion.identity);
            Destroy(gameObject.transform.parent.gameObject);
            roomCreator.DestroyEnemy();
        }
    }

    IEnumerator DamageRecived()
    {
        if(movementScript != null)
        {
            animator.SetBool("IsDamaged", true);
            float initialSpeed = movementScript.moveSpeed;
            movementScript.moveSpeed = 0;

            yield return new WaitForSeconds(0.5f);

            animator.SetBool("IsDamaged", false);
            movementScript.moveSpeed = initialSpeed;
        }
    }
}
