using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;

    public Coroutine deathAnim { private set; get; }

    // Start is called before the first frame update
    void Start()
    {
        _particles.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // death animation coroutine
    public IEnumerator Die()
    {
        // rotate the game object as if it fell
        this.transform.Rotate(-75, 0, 0);

        // turn on particles 
        _particles.enableEmission = true;

        // wait 1.5 seonds
        yield return new WaitForSeconds(1.5f);

        // dies
        Destroy(gameObject);
    }

    public void ReactToHit()
    {
        // pass in FALSE if script is attached
        // reference to wandering AI script
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }

        // die
        if (deathAnim == null) deathAnim = StartCoroutine(Die());
    }
}
