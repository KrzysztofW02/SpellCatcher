using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int EnemyMaxHp;
    public int EnemyHP;
    void Start()
    {
        EnemyMaxHp = 15;
        EnemyHP = EnemyMaxHp;
        StartCoroutine(ExecuteFunctionEverySecond());
    }

    IEnumerator ExecuteFunctionEverySecond()
    {
        while (true)
        {
            EnemyHP -= 1;
            yield return new WaitForSeconds(1.0f); // Wait for 1 second
        }
    }
    void Update()
    {
        if(EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
