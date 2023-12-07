using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class EnemyShooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private GameObject Player;
    private bool waiting = false;

    // Update is called once per frame
    void Update()
    {
        if(waiting ==false)
        {
            StartCoroutine(Firebullet());
        }
    }

    IEnumerator Firebullet()
    {
        waiting = true;
        // Pobierz pozycj� myszy w przestrzeni �wiata gry
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPosition.z = 0f; // Ustaw z na 0, aby utrzyma� wszystko na p�aszczy�nie gry

        // Oblicz kierunek od strza�u do pozycji myszy
        Vector3 shootDirection = (playerPosition - shootingPoint.position).normalized;

        // Oblicz k�t obrotu kulki na podstawie kierunku
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        // Stw�rz kul�, ustawiaj�c jej pozycj�, obr�t i pr�dko��
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0f, 0f, angle));
        if(bullet != null)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bullet.GetComponent<EnemyBullet>().speed;
        }
        yield return new WaitForSeconds(Random.Range(1f,3f));
        waiting = false;
    }
}
