using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpwaner : MonoBehaviour
{
    public List<Enemys> enemies = new List<Enemys>();
    public int currentWave;
    public int waveValue;
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public Transform spawnLocation;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    private void Start()
    {
        GenerateWave();
    }
    private void FixedUpdate()
    {
        if(spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer = Time.fixedDeltaTime;
            waveTimer = Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randEnemyID = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyID].cost;

            if(waveValue - randEnemyCost  >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyID].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}


[System.Serializable]
public class Enemys
{
    public GameObject enemyPrefab;
    public int cost;
}
