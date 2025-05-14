using UnityEngine;
using System.Collections.Generic;
using System.Collections;



//
//  This Script is meant to be used as a separate AI from the Original AI script. The AI script was used as the framework for this one, so depending on how the waypoints system works, changes to the code may be necessary
//
//
//
public class AggresiveAI : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 50f;
    public float rotationSpeed = 200f;
    int index = 0;
    public float initialXOffset = 0f;
    public float initialZOffset = 0f;


    // start of Projectile code
    [SerializeField] GameObject slimeballPrefab;
    private GameObject slimeball;

    [SerializeField] GameObject TslimePrefab;
    private GameObject Tslime;

    InventoryScript inventory;
    private GameObject player;

    private int SlimeAmmo = 0;
    private int TSlimeAmmo = 0;
    private float cooldown = 0;
    private int clear;
    

    public void addSlimeAmmo(int supply)
    {
        SlimeAmmo = supply;
    }

    public void addTSlimeAmmo(int supply)
    {
        TSlimeAmmo = supply;
    }

    // used to reset the inventory space
    public void objectSize(int size)
    {
        clear = size;
    }
    // End of Projectile code



    private float Timer;
    private float totalModifier = 1f;
    private bool isNormalSpeed;
    private float oilModifier = 1f;

    public void modifySpeed(float speedModifier)
    {
        speed *= speedModifier;
        totalModifier *= speedModifier;
        Timer = 5f;
        isNormalSpeed = false;
    }

    public void undoSpeedModifier()
    {
        speed = speed / totalModifier;
        totalModifier = 1f;
        isNormalSpeed = true;
    }

    public void applyOilSlick(float modifier)
    {
        speed *= modifier;
        oilModifier = modifier;
    }

    public void removeOilSlick()
    {
        speed /= oilModifier;
    }

    // Grabs the Inventory script from the object that this code is placed on, which should be the AI model. If this script is not on the main body, but the inventory script is, use GetComponentInParent instead.
    // Also locates the player game object in the scene
    void start()
    {
        inventory = GetComponent<InventoryScript>();

        player = GameObject.Find("player");

        
    }

    // Update is called once per frame
    private void Update()
    {
        // Move Forward to Waypoints
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        float distance = Vector3.Distance(transform.position, destination);


        // Start of aiming and firing code
        // NOTE: Cooldown of projectiles is coded to twice the cooldown of the player's. Can be changed for balancing.

        // checks if AI has ammo for any type of slime
        if (SlimeAmmo != 0 || TSlimeAmmo != 0)
        {
            // basic slime ammo must be present and there can't be a cooldown
            if (SlimeAmmo != 0 && cooldown <= 0f)
            {
                // AI snaps its rotation to look at the world cordinates for the player
                transform.LookAt(player.transform.position); 
                
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    // checks if the object in its view has the player character component
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        // fires a basic slimeball forward, subtracts from the basic slime ammo, and sets the cooldown between shots 
                        slimeball = Instantiate(slimeballPrefab) as GameObject;
                        slimeball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        slimeball.transform.rotation = transform.rotation;
                        SlimeAmmo -= 1;
                        cooldown = 1f;
                    }
                }
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
            // tracking slime ammo must be present and there can't be a cooldown
            if (TSlimeAmmo != 0 && cooldown <= 0f)
            {
                // AI snaps its rotation to look at the world cordinates for the player
                transform.LookAt(player.transform.position);

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    // checks if the object in its view has the player character component
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        // fires a tracking slimeball forward, subtracts from the basic slime ammo, and sets the cooldown between shots 
                        Tslime = Instantiate(TslimePrefab) as GameObject;
                        Tslime.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        Tslime.transform.rotation = transform.rotation;
                        TSlimeAmmo -= 1;
                        cooldown = 4f;

                    }
                }
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
        // End of aiming and firing code
        //


        Vector3 direction = destination - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            Vector3 eulerRotation = targetRotation.eulerAngles;
            eulerRotation.x = 0;
            eulerRotation.z = 0;
            Quaternion newRotation = Quaternion.Euler(eulerRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = transform.rotation * Quaternion.Euler(initialXOffset, 0, initialZOffset);
        }


        // Makes sure AI moves
        if (distance <= 0.05)
        {
            index++;
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }else if (!isNormalSpeed)
        {
            undoSpeedModifier();
        }
    }
}
