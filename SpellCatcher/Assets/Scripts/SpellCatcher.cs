using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCatcher : MonoBehaviour
{
    public Player player;
    public EnergyBar energyBar;
    public bool IsOnCooldown = false;
    public float CooldownTime = 1f;
    public List<GameObject> TriggerList = new List<GameObject>();

    public Animator animator;
    public AudioSource src;
    public AudioClip sfx1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnCooldown == false)
        {
            GetAllObjectsInTrigger();

            foreach (var item in TriggerList)
            {
                if (item == null)
                {
                    continue;
                }

                if (item.GetComponent<EnemyBullet>() != null)
                {
                    Destroy(item);
                    SpellCatched();
                }
                else if (item.GetComponent<EnemyBase>() != null)
                {
                    item.GetComponent<EnemyBase>().TakeDamage(5);
                    SpellCatched();
                }
                else if (item.GetComponent<DestroyableItem>() != null)
                {
                    item.GetComponent<DestroyableItem>().TakeDamage(5);
                    SpellCatched();
                }
            }

            TriggerList.Clear();
        }
    }

    public void GetAllObjectsInTrigger()
    {
        TriggerList.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            TriggerList.Add(collider.gameObject);
        }
    }

    public void SpellCatched()
    {
        IsUsed();
        src.clip = sfx1;
        src.Play();
        if (animator != null)
        {
            animator.SetBool("IsSpellCatcher", true);
            StartCoroutine(ResetSpellCatcherAnimation());
        }
        if (player.Energy < player.MaxEnergy)
        {
            player.Energy += 1;
            energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);
        }
    }

    IEnumerator ResetSpellCatcherAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("IsSpellCatcher", false);
    }

    public void IsUsed()
    {
        StopCoroutine("CooldownCounter");
        StartCoroutine(CooldownCounter());
    }

    IEnumerator CooldownCounter()
    {
        IsOnCooldown = true;
        yield return new WaitForSeconds(CooldownTime);

        IsOnCooldown = false;
    }
}
