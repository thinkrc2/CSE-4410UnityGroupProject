using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;

    [SerializeField] GameObject bossPrefab;

    private GameObject enemy;
    private GameObject boss;

    private int bossCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(enemy == null && boss == null)
        {
            if(bossCounter == 5)
            {
                boss = Instantiate(bossPrefab) as GameObject;
                boss.transform.position = new Vector3(0f, 1.5f, 0f);
                float angle = Random.Range(0, 360);
                boss.transform.Rotate(0, angle, 0);
                bossCounter = 0;
            }
            else
            {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemy.transform.position = new Vector3(0f, 1.5f, 0f);
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);
                bossCounter += 1;
            }

        }
    }
}
