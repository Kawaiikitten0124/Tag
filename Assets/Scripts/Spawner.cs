using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Spawner : MonoBehaviour

{
    public GameObject[] SpherePrefab;
    private float spawnRangeX = 10;
    private float spawnRangeZ = 10;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public Transform Spheretarget;
    public float targetTime;
    public Text TimerText;
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
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            TimeEnded();
            targetTime = 0.0f;
        }
        TimerText.text = ((int)targetTime).ToString();
    }
    void SpawnRandomSphere()
    {
        int SphereIndex = Random.Range(0, SpherePrefab.Length);
        Vector3 SpawnRange = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, (Random.Range(-spawnRangeZ, spawnRangeZ)));


        Instantiate(SpherePrefab[SphereIndex], SpawnRange, SpherePrefab[SphereIndex].transform.rotation, Spheretarget);
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
        Destroy(Spheretarget.gameObject);
    }

}  
