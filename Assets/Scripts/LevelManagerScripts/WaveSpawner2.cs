using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner2 : MonoBehaviour
{
    
    public enum SpawnState {spawning, waiting, counting};

    [System.Serializable]
    public class Wave
    {
        public string name; // name of wave
        public Transform enemy; //prefab to instantiate
        public int count; //wavecount
        public float rate;  //spawn rate
        
    }

    public Wave[] waves; //array to set number of waves
    private int nextWave = 0;//stores index of wave to create next

    public Transform[] spawnPoints;

    public float timeBtwWaves = 5f;  //time between waves
    public float waveCountdown; //countdown to next wave

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.counting;

    private bool triggered = false; // trigger start wavespawner

    void Start()
    {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError ("No spawn points referenced");
        }

        waveCountdown = timeBtwWaves;

    } 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    void Update()
    { 
        if (triggered)
        {
            if (state == SpawnState.waiting)  //to check if enemies are alive
            {
                if (!EnemyIsAlive()) // begin new round
                 {
                     WaveCompleted();
                 }
                     else
                    {
                     return;
                    }
            }

            if (waveCountdown <= 0)
            {
                 if (state != SpawnState.spawning) //start spawning wave
                {
                    StartCoroutine(SpawnWave (waves[nextWave]));

                }
            } 
             else
            {
            waveCountdown -= Time.deltaTime;
            }
        }
        
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.counting;
        waveCountdown = timeBtwWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            Destroy(gameObject);
            Debug.Log("All Waves Complete!");  //next steps from here

        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {

        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        
        }

         return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log ("Spawning Wave" + _wave.name);
        state = SpawnState.spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy (_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //spawn enemy
        
        Debug.Log ("Spawning Enemy:" + _enemy.name);

        Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
        Instantiate (_enemy, _sp.position, _sp.rotation);
    }

}
