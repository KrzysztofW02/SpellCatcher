using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public int MaxHP = 15;
    public float Energy;
    public float MaxEnergy = 5;
    public int Level = 1;
    public int Experience = 0;
    
    public GameOver GameOver;
    
    public GameObject[] Enemies; 

    public HealthBar healthBar;
    void Start()
    {
        HP = MaxHP;
        healthBar = GetComponentInChildren<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0 || HP < 0)
        {
            GameOver.Setup();
            Destroy(gameObject);
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in Enemies) {Destroy(enemy);}
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        healthBar.UpdateHealthBar(HP, MaxHP);
    }

    public void Heal(int heal)
    {
        if (HP + heal > MaxHP)
            HP = MaxHP;
        else
            HP += heal;

        healthBar.UpdateHealthBar(HP, MaxHP);
    }
    public void AddExperience(int exp)
    {
        Experience += exp;
        if (Experience >= 50*Level)
        {
            Level++;
            Experience = 0;
        }
    }
}
