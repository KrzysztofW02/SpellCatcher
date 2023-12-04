using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Pobierz pozycj� myszy w przestrzeni �wiata gry
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ustaw z na 0, aby utrzyma� wszystko na p�aszczy�nie gry

            // Oblicz kierunek od strza�u do pozycji myszy
            Vector3 shootDirection = (mousePosition - shootingPoint.position).normalized;

            // Oblicz k�t obrotu kulki na podstawie kierunku
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

            // Stw�rz kul�, ustawiaj�c jej pozycj�, obr�t i pr�dko��
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0f, 0f, angle));
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bullet.GetComponent<Bullet>().speed;
        }
    }

}
