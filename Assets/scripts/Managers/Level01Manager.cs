using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Manager : MonoBehaviour
{
    public Transform[] badSpawn;
    public GameObject badPrefabs;
    public int badWaves = 3;
    public float waitTimeFirstWave = 3f;
    public float waitTimeBetweenWaves = 10f;
    void Start()
    {
        
    }

    IEnumerator SpawnBad()
    {
        yield return new WaitForSeconds (waitTimeFirstWave);
        for (int i=0; i<badWaves;i++)
        {

        }
    }


}
