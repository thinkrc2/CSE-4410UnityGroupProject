using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectShooter : MonoBehaviour
{
    [SerializeField] GameObject slimeballPrefab;
    private GameObject slimeball;

    [SerializeField] GameObject TslimePrefab;
    private GameObject Tslime;

    InventoryScript inventory;

    private Camera cam;
    public int damage = 1;

    private int ammo = 0;
    private int ammo2 = 0;
    private float cooldown = 0;

    private int clear;

    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        inventory = GetComponentInParent<InventoryScript>();
    }

    private void OnGUI()
    {
        int size = 24;

        float posX = cam.pixelWidth / 2;
        float posY = cam.pixelHeight / 2;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // adds ammo depending on which pickup was triggered
    public void addSlimeAmmo(int supply)
    {
        ammo = supply;
    }

    public void addTSlimeAmmo(int supply)
    {
        ammo2 = supply;
    }

    // used to reset the inventory space
    public void objectSize(int size)
    {
        clear = size;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (ammo > 0)
            {
                // Fires a simple object that slows the player. also adds a cooldown to prevent spam of projectiles
                if(cooldown <= 0)
                {
                    slimeball = Instantiate(slimeballPrefab) as GameObject;
                    slimeball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    slimeball.transform.rotation = transform.rotation;
                    ammo -= 1;
                    cooldown = 0.5f;
                }
                else
                {
                    cooldown -= Time.deltaTime;
                }
            }
            else
            {
                inventory.removeFromInventory(clear);
                cooldown = 0;
            }

            
            if (ammo2 > 0)
            {
                // Same as the last one, but for a different projectile
                if (cooldown <= 0)
                {
                    Tslime = Instantiate(TslimePrefab) as GameObject;
                    Tslime.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    Tslime.transform.rotation = transform.rotation;
                    ammo2 -= 1;
                    cooldown = 2f;
                }
                else
                {
                    cooldown -= Time.deltaTime;
                }
            }
            else
            {
                inventory.removeFromInventory(clear);
                cooldown = 0;
            }

        }
    }
}