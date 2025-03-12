using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WanderingAIJ : MonoBehaviour
{

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    public float speed = 3f;
   
    public float obstacleRange = 5f;

    private bool isAlive;

    


    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAlive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            //y axis translation added as well
            // vector 3 was transform.translate
            transform.Translate(0, 0, speed * Time.deltaTime);
            
        }

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacterJ>())
            {
                if(fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
