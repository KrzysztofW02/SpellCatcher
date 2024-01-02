using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitPickUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MedKitPickUp");

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().Heal(other.gameObject.GetComponent<Player>().MaxHP/3);
            Destroy(gameObject);
        }
        
    }
}
