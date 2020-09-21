using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1f;
    public float xPos = 22f;
    public float yPos = 22f;
  
    

    // Use this for initialization
    void Start()
    {
        
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        a.transform.position = new Vector2(Mathf.Round(Random.Range(-xPos , xPos)), Mathf.Round(Random.Range(-yPos, yPos)));
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
