using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Player player;
    public EnergyBar energyBar;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.Energy > 0)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; 

            Vector3 shootDirection = (mousePosition - shootingPoint.position).normalized;

            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0f, 0f, angle));
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bullet.GetComponent<Bullet>().speed;
            player.Energy -= 1;
            energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);
        }
    }

}
