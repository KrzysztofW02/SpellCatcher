using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Player player;
    public EnergyBar energyBar;
    public Button[] statButtons;
    public Animator playerAnimator;
    public AudioSource src;
    public AudioClip sfx1;

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player.Energy > 0 && !IsPointerOverStatButtons() && !isAttacking)
        {
            StartCoroutine(ShootAndAnimate());
        }
    }

    IEnumerator ShootAndAnimate()
    {
        isAttacking = true;

        src.clip = sfx1;
        src.Play();

        if (playerAnimator != null)
        {
            playerAnimator.SetBool("IsAttack", true);
            yield return new WaitForSeconds(0.5f);
            playerAnimator.SetBool("IsAttack", false);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Vector3 shootDirection = (mousePosition - shootingPoint.position).normalized;
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bullet.GetComponent<Bullet>().speed;

        player.Energy -= 0.5f;
        energyBar.UpdateEnergyBar(player.Energy, player.MaxEnergy);

        isAttacking = false;
    }

    private bool IsPointerOverStatButtons()
    {
        foreach (Button statButton in statButtons)
        {
            if (IsPointerOverButton(statButton))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsPointerOverButton(Button button)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == button.gameObject)
            {
                return true;
            }
        }

        return false;
    }
}
