using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReactiveTargetJ : MonoBehaviour
{

    public void ReactToHit()
    {

        WanderingAIJ behavior = GetComponent<WanderingAIJ>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {

        this.transform.Rotate(-75, 0 , 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
