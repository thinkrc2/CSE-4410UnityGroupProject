using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReactiveHitJ : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit()
    {
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        transform.Rotate(-90,0,0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
