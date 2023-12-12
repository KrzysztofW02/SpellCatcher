using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public int MaxHP = 50;
    public GameOver GameOver;
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            GameOver.Setup();
            //Time.timeScale = 0f;
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
