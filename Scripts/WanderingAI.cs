using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    // projectile to shoot
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    // obstacle detection and movement
    public float speed = 3f;
    public float obstacleRange = 5f;

    private bool isAlive;

    public const float _baseSpeed = 3f;

    public void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = _baseSpeed * value;
    }

    private void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // move
        transform.Translate(0, 0, speed * Time.deltaTime);

        // create a ray in same direction of movement
        Ray ray = new Ray(transform.position, transform.forward);

        // sphere cast
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            // get a reference to the game object hit by the spherecast
            GameObject hitObject = hit.transform.gameObject;

            // if the object hit was the player, shoot a fireball at player
            // otherwise, the object is within the object range, turn around
            if (hitObject.GetComponent<PlayerCharacter>()) {
                if (fireball == null) {
                    fireball = Instantiate(fireballPrefab) as GameObject;
                    fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }

            // if ray had hit something and its distance is less than object range, turn a random rotation
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
    // public method to set isAlive
    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
}
