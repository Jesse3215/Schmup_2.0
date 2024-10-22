using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FreezeProjectile : MonoBehaviour
{
    public Rigidbody2D rb;

    public int bulletSpeed;

    private PlayerMovement playermovement;

    private void Awake()
    {
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void ShootEnemy()
    {
        rb.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            StartCoroutine(playermovement.Freeze());
        }
        Destroy(gameObject);
    }


}
