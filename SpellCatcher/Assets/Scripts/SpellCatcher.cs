using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(""))
        {
            //Destroy(gameObject);
        }
    }
}
