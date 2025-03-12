using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedSpawner : MonoBehaviour
{

    [SerializeField] GameObject speedboostPrefab;

    private GameObject speedboost;
    private SpeedSpawner spawner;
    private float spawnTimer = 10f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GetComponent<SpeedSpawner>();
        speedboost = Instantiate(speedboostPrefab) as GameObject;
        // spawns prefab 1.5m above this object
        speedboost.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (speedboost == null)
        {
            // 10 second timer before a new object is created
            if (spawnTimer <= 0)
            {
                speedboost = Instantiate(speedboostPrefab) as GameObject;
                speedboost.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);

                spawnTimer = 10f;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }

        }
    }
}
