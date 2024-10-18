using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public int bulletSpeed;

    private WaveSpwaner waveSpwaner;

    private void Start()
    {
        waveSpwaner = FindAnyObjectByType<WaveSpwaner>();

        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            waveSpwaner.enemiesSpawned.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }


}
