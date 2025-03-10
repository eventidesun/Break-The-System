using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float shootingInterval = 2f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float moveDistance = 3f;

    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
        InvokeRepeating(nameof(Shoot), shootingInterval, shootingInterval);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= startPosition.x + moveDistance)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= startPosition.x - moveDistance)
                movingRight = true;
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0); // Shoots left
    }
}
