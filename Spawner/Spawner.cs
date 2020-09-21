using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnObject; // Choose an object to be spawned
    public float respawnTime = 1f;
    public float xPos = 22f; // max x
    public float yPos = 22f; // max y
  
    

    // Use this for initialization
    void Start()
    {  
        StartCoroutine(Timer());
    }

    private void spawnObject()
    {
        GameObject a = Instantiate(SpawnObject) as GameObject;
        // Remove Mathf.Round if you don't want to round x&y position
        a.transform.position = new Vector2(Mathf.Round(Random.Range(-xPos , xPos)), Mathf.Round(Random.Range(-yPos, yPos))); 
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }
    }
}
