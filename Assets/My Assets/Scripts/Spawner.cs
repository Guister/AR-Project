using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Spawner : MonoBehaviour {

    public GameObject[] obj;
    public Transform[] pos;
    public float spawnMin = 0.5f;
    public float spawnMax = 1f;
    public static int obstaclesSpawned = 0;
    public float difficulty = 0;
    public static bool clicked = false;
    // Use this for initialization
    void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0) && clicked == false)
        {
            Spawn();
            clicked = true;
        }
       
    }

   public void Spawn()
    {
        difficulty = obstaclesSpawned * 0.0005f;
        int spawnlocation = Random.Range(0, pos.Length);
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], pos[spawnlocation].position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        obstaclesSpawned++;

        while (spawnMin >= 0.4f)
        {
            spawnMin = spawnMin - difficulty;
            Debug.Log("SpawnMin: " + spawnMin);
            break;
        }
        while (spawnMax >= 0.6f)
        {
            spawnMax = spawnMax - difficulty;
            Debug.Log("SpawnMax: " + spawnMax);
            break;
        }
    }
}
