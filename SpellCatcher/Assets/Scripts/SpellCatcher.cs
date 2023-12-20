using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCatcher : MonoBehaviour
{
    public Player player;
    public EnergyBar energyBar;

    public void SpellCatched()
    {
        player.Energy += 1;
        Debug.Log("Energy" + player.Energy);
        energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);
    }
}
