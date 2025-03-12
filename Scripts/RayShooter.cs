using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RayShooter : MonoBehaviour
{

    private Camera cam;
    public int damage = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 24;

        float posX = cam.pixelWidth / 2;
        float posY = cam.pixelHeight / 2;



        GUI.Label(new Rect(posX, posY, size, size), "*");

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

            Ray ray = cam.ScreenPointToRay(point);


            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();


                BossCharacter Boss = hitObject.GetComponent<BossCharacter>();

                if (Boss != null)
                {
                    Boss.Hurt(damage);
                }
                else
                {
                    if (target != null)
                    {
                        target.ReactToHit();

                    }
                    else
                    {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }
                
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.transform.position = pos;

        sphere.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}

