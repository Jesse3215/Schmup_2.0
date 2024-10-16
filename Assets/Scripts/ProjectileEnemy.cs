using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public int bulletSpeed;

    private PlayerMovement health;

    public void ShootEnemy()
    {
        rb.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
