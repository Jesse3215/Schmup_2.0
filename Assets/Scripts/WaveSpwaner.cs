using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpwaner : MonoBehaviour
{
    [SerializeField] public List<GameObject> enemiesSpawned = new List<GameObject>();
    public GameObject enemyClone;

    private float rightPos = 9.39f;
    private float leftPos = -9.39f;

    public TextMeshProUGUI waveCountText;
    int waveCount = 0;

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount = 1;

    public GameObject enemy;

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();

        /*if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }*/

        if(enemiesSpawned.Count <= 0) 
        {
            waveCount += 1;
            StartCoroutine(waveSpawner());
        }

    }

    IEnumerator waveSpawner()
    {

        for (int i = 0; i < enemyCount; i++)
        {
            enemyClone = Instantiate(enemy, transform.position + Vector3.right * Random.Range(leftPos, rightPos), Quaternion.Euler(new Vector3(0, 0, 180)));

            enemiesSpawned.Add(enemyClone);

            yield return new WaitForSeconds(spawnRate);
        }

        //spawnRate -= 0.1f;
        enemyCount += 1;

        yield return new WaitForSeconds(timeBetweenWaves);

    }
}



