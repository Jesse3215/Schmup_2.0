using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    [SerializeField] Vector3 topright;
    [SerializeField] Vector3 topleft;
    [SerializeField] Vector3 bottomleft;
    [SerializeField] Vector3 bottomright;


    public GameObject plane;

    private void Awake()
    {
        topleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 20));
        topright = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 20));
        bottomright = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 20));
        bottomleft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 20));
    }
    void Start()
    {

    }


    void Update()
    {

        if (transform.position.x < topleft.x - 1)
        {
            transform.position = new Vector3(topright.x, transform.position.y, transform.position.z);
        }

        if (transform.position.x > topright.x + 1)
        {
            transform.position = new Vector3(topleft.x, transform.position.y, transform.position.z);
        }

        if (transform.position.z < bottomleft.z - 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topleft.z);
        }

        if (transform.position.z > topleft.z + 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomleft.z);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(topleft, topright);
        Gizmos.DrawLine(topright, bottomright);
        Gizmos.DrawLine(bottomright, bottomleft);
        Gizmos.DrawLine(bottomleft, topleft);

    }
}
