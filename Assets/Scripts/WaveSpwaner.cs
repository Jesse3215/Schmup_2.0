using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpwaner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    int waveCount = 1;

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount = 1;

    public GameObject enemy;

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject enemyClone = Instantiate(enemy, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));

            yield return new WaitForSeconds(spawnRate);
        }

        //spawnRate -= 0.1f;
       enemyCount += 1;
        waveCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true;
    }
}



