using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipe;
    public float spawnInterval = 2f;
    private float timer = 0f;
    public float heightOffset = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }
    private void SpawnObject()
    {
        // Instantiate the game object at the spawner's position
        var minSpawnHeight = transform.position.y - heightOffset;
        var maxSpawnHeight = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minSpawnHeight, maxSpawnHeight), transform.position.y) , Quaternion.identity);
    }
}
