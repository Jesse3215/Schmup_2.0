using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] powerups;
    private float randomTime;

    void Start()
    {
        randomTime = Random.Range(10f, 20f);
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(randomTime);
        Vector3 position = new Vector3(Random.Range(-9.39f, 9.39f), -4.11f, 0);
        Instantiate(powerups[Random.Range(0, powerups.Length)], position, Quaternion.identity);
        StartCoroutine(spawn());
    }
}
