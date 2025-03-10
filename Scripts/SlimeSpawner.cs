using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject slimeballPrefab;

    private GameObject slimeball;
    private SlimeSpawner spawner;
    private float spawnTimer = 10f;

    void Start()
    {
        spawner = GetComponent<SlimeSpawner>();
        slimeball = Instantiate(slimeballPrefab) as GameObject;
        // spawns prefab 1.5m above this object
        slimeball.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (slimeball == null)
        {
            // 10 second timer before a new object is created
            if (spawnTimer <= 0)
            {
                slimeball = Instantiate(slimeballPrefab) as GameObject;
                slimeball.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);

                spawnTimer = 10f;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }

        }
    }
}
