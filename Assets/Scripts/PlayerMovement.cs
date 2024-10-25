using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;

    private Vector2 moveDirection;

    private Projectile projectile;

    public InputActionReference move;
    public InputActionReference fire;

    public GameObject projectilePrefab;
    public Transform spawnPosition;

    public int playerHealth = 3;

    [SerializeField] private GameObject Live1;
    [SerializeField] private GameObject Live2;
    [SerializeField] private GameObject Live3;

    public GameObject GainHPVisuel;
    public GameObject LoseHPVisuel;

    private Animator AnimationRight;
    private Animator AnimationLeft;

    private bool Frooze;

    private void Start()
    {
        AnimationRight = GetComponent<Animator>();
        AnimationLeft = GetComponent<Animator>();

        projectile = GetComponent<Projectile>();

        GainHPVisuel.SetActive(false);
        LoseHPVisuel.SetActive(false);
    }

    private void Update()
    {
        if (!Frooze) 
        {
            moveDirection = move.action.ReadValue<Vector2>();
        }
        else if(Frooze)
        {
            moveDirection = Vector2.zero;
        }
        

        if(move.action.ReadValue<Vector2>().x == 1)
        {
            AnimationLeft.SetBool("Left 0", false);
            AnimationRight.SetBool("Right 0", true);
        }

        if (move.action.ReadValue<Vector2>().x == -1)
        {
            AnimationRight.SetBool("Right 0", false);
            AnimationLeft.SetBool("Left 0", true);
        }

        if (move.action.ReadValue<Vector2>().x == 0)
        {
            AnimationRight.SetBool("Right 0", false);
            AnimationLeft.SetBool("Left 0", false);
        }

        if (playerHealth == 3)
        {
            Live1.SetActive(true);
            Live2.SetActive(true);
            Live3.SetActive(true);
        }
        if (playerHealth == 2)
        {
            Live1.SetActive(true);
            Live2.SetActive(true);
            Live3.SetActive(false);
        }
        if (playerHealth == 1)
        {
            Live1.SetActive(true);
            Live2.SetActive(false);
            Live3.SetActive(false);
        }
    }

    public void StartFreeze()
    {
        StartCoroutine(Freeze());   
    }

    public IEnumerator Freeze()
    {
        Frooze = true;
        yield return new WaitForSeconds(2.5f);
        Frooze = false;
    }

    private IEnumerator Spray()
    {
        projectile.bulletSpeed = 5;
        yield return new WaitForSeconds(5f);
        projectile.bulletSpeed = 10;
        StopCoroutine(Spray());
    }

    private IEnumerator OnHit()
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        LoseHPVisuel.SetActive(true);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.cyan;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        LoseHPVisuel.SetActive(false);
    }

    public IEnumerator GetHealth()
    {
        GainHPVisuel.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Debug.Log("False");
        GainHPVisuel.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        StopCoroutine(GetHealth());
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Instantiate(projectilePrefab, spawnPosition.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            StartCoroutine(OnHit());
            playerHealth -= 1;
        }

        if (collision.gameObject.CompareTag("PickUps"))
        {
            if (playerHealth == 3)
            {
                playerHealth = 3;
            }

            if (playerHealth == 2)
            {
                playerHealth++;
                StartCoroutine(GetHealth());
            }

            if (playerHealth == 1)
            {
                playerHealth++;
                StartCoroutine(GetHealth());
            }
        }

        if (collision.gameObject.CompareTag("PickUpFireSpeed"))
        {
            StartCoroutine(Spray());
        }

        Debug.Log(playerHealth);
        

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            Live1.SetActive(false);
            Live2.SetActive(false);
            Live3.SetActive(false);
        }
    }
}
