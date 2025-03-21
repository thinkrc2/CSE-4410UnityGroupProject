using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossCharacter : MonoBehaviour
{

    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 5;
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health Remaining: {health}");

    }

    public void ReactToHit()
    {

        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {

        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        BossCharacter Boss = GetComponent<BossCharacter>();

        if (health == 0)
        {
            Boss.ReactToHit();
        }
    }
}
