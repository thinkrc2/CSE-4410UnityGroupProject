using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TslimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject TslimePickupPrefab;

    private GameObject TslimePickup;
    private TslimeSpawner spawner;
    private float spawnTimer = 10f;

    void Start()
    {
        spawner = GetComponent<TslimeSpawner>();
        TslimePickup = Instantiate(TslimePickupPrefab) as GameObject;
        // spawns prefab 1.5m above this object
        TslimePickup.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);
    }

    void Update()
    {
        if (TslimePickup == null)
        {
            // 10 second timer before a new object is created
            if (spawnTimer <= 0)
            {
                TslimePickup = Instantiate(TslimePickupPrefab) as GameObject;
                TslimePickup.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);

                spawnTimer = 10f;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }

        }
    }
}
