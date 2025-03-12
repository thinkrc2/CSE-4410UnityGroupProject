using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TslimeSpawner : MonoBehaviour
{
    [SerializeField] GameObject TslimePrefab;

    private GameObject Tslime;
    private TslimeSpawner spawner;
    private float spawnTimer = 10f;

    void Start()
    {
        spawner = GetComponent<TslimeSpawner>();
        Tslime = Instantiate(TslimePrefab) as GameObject;
        // spawns prefab 1.5m above this object
        Tslime.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);
    }

    void Update()
    {
        if (Tslime == null)
        {
            // 10 second timer before a new object is created
            if (spawnTimer <= 0)
            {
                Tslime = Instantiate(TslimePrefab) as GameObject;
                Tslime.transform.position = spawner.transform.position + new Vector3(0f, 1.5f, 0f);

                spawnTimer = 10f;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }

        }
    }
}
