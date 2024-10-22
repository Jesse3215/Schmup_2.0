using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public int bulletSpeed;

    private void Start()
    {

        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


}
