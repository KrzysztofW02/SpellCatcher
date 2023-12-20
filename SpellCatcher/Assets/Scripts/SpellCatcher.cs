using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCatcher : MonoBehaviour
{
    public Player player;
    public EnergyBar energyBar;
    public bool IsOnCooldown = false;

    public void SpellCatched()
    {
        player.Energy += 1;
        Debug.Log("Energy" + player.Energy);
        energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);
    }
    public void IsUsed()
    {
        StartCoroutine(CooldownCounter());
    }
    IEnumerator CooldownCounter()
    {
        IsOnCooldown = true;
        yield return new WaitForSeconds(3f);
        IsOnCooldown = false;
        Debug.Log("cooldown");
    }
}
