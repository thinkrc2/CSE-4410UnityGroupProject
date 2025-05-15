using UnityEngine;

public class Blaster : MonoBehaviour
{
    [SerializeField] GameObject slimeballPrefab;
    private GameObject slimeball;

    private int ammo = 10;
    private float cooldown = 0f;

    // Update is called once per frame
    void Update()
    {

        if (cooldown <= 0f)
        {
            slimeball = Instantiate(slimeballPrefab) as GameObject;
            slimeball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            slimeball.transform.rotation = transform.rotation;
            ammo -= 1;
            cooldown = 0.35f;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
}
