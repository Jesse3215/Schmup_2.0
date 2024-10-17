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

    public InputActionReference move;
    public InputActionReference fire;

    public GameObject projectilePrefab;
    public Transform spawnPosition;

    public int playerHealth = 3;

    [SerializeField] private GameObject Live1;
    [SerializeField] private GameObject Live2;
    [SerializeField] private GameObject Live3;

    [SerializeField] private Animator AnimationRight;
    [SerializeField] private Animator AnimationLeft;

    private void Start()
    {
        AnimationRight = GetComponent<Animator>();
        AnimationLeft = GetComponent<Animator>();
    }

    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();

        if(move.action.ReadValue<Vector2>().x == 1)
        {
            AnimationRight.SetBool("Right 0", true);
        }

        if (move.action.ReadValue<Vector2>().x == -1)
        {
            AnimationRight.SetBool("Left 0", true);
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
        playerHealth -= 1;
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
