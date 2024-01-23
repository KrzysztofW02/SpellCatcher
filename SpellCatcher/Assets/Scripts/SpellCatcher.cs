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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnCooldown == false)
        {
            GetAllObjectsInTrigger();
            for(int i = 0; i < TriggerList.Count; i++)
            {
                var item = TriggerList[i];
                if (item.GetComponent<EnemyBullet>() != null)
                {
                    Destroy(item);
                    SpellCatched();
                    TriggerList.Remove(item);
                }
                else if (item.GetComponent<EnemyBase>() != null)
                {
                    item.GetComponent<EnemyBase>().TakeDamage(5);
                    SpellCatched();
                    TriggerList.Remove(item);
                }
                else if (item.GetComponent<DestroyableItem>() != null)
                {
                    item.GetComponent<DestroyableItem>().TakeDamage(5);
                    SpellCatched();
                } 
            }
        }
    }

    public void GetAllObjectsInTrigger()
    {
        TriggerList.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        foreach (Collider2D collider in colliders)
        {
            TriggerList.Add(collider.gameObject);
        }
    }
    public void SpellCatched()
    {
        if (player.Energy < 5)
        {
            player.Energy += 1;
            Debug.Log("Energy" + player.Energy);
            energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);
            IsUsed();

            if (animator != null)
            {
                animator.SetBool("IsSpellCatcher", true);
            }
        }
    }
    public void IsUsed()
    {
        StartCoroutine(CooldownCounter());
    }
    IEnumerator CooldownCounter()
    {
        IsOnCooldown = true;
        yield return new WaitForSeconds(CooldownTime);

        if (animator != null)
        {
            animator.SetBool("IsSpellCatcher", false);
        }

        IsOnCooldown = false;
        Debug.Log("cooldown");
    }
}