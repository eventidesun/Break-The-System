using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float fireRate = 0.5f;

    private float nextFireTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        float direction = transform.localScale.x;
        projectile.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(direction * 10f, 0);

        // Flip projectile if facing left
        if (direction < 0)
            projectile.transform.localScale = new Vector3(-1, 1, 1);
    }
}
