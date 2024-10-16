using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5f;

    [SerializeField] private float rightpos;
    [SerializeField] private float leftpos;

    [SerializeField] private bool movingRight = true;
    [SerializeField] private bool movingLeft = false;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform spawnPosition;

    public int hitpoints = 2;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {

        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x <= rightpos)
            {
                movingRight = false;
                movingLeft = true;
            }

        }
        if (movingLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);


            if (transform.position.x >= leftpos)
            {
                movingLeft = false;
                movingRight = true;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(OnHit());
    }



    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition.position, Quaternion.identity);
            projectile.GetComponent<ProjectileEnemy>().ShootEnemy();
            yield return new WaitForSeconds(0.7f);
        }
        
    }

    private IEnumerator OnHit()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
}
