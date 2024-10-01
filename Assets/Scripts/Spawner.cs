using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{
    public GameObject[] SpherePrefab;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 10;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private float targetTime = 10.0f;
    //private bool GameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWave", startDelay, spawnInterval); 
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyUp(KeyCode.S))
      {
            SpawnWave();

      }
        targetTime = Time.deltaTime;
        if (targetTime <=0.0f)
        {
            TimeEnded();
        }
    } 
    void SpawnRandomSphere()
    {
        int SphereIndex = Random.Range(0, SpherePrefab.Length);
        Vector3 SpawnRange = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, (Random.Range(-spawnRangeZ, spawnRangeZ)));


        Instantiate(SpherePrefab[SphereIndex], SpawnRange, SpherePrefab[SphereIndex].transform.rotation); 
    }
    void SpawnWave()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnRandomSphere();
        }

    }
    void TimeEnded()
    {
        CancelInvoke();
    }
}
