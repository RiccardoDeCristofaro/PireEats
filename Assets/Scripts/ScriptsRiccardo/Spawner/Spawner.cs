using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Camera cam;
    //Go
    public GameObject potato;
    public GameObject fish;
    public GameObject ham;
    public GameObject spice;
    //transform
    private Transform spiceSpawn;
    public Transform spawnPointPot;
    public Transform spawnPointFish;
    public Transform spawnHam;
    // settings
    public GameObject playerRotationPoint;
    [SerializeField]
    public float rotX, rotY, rotZ;
    private bool recentlySpawned = false;

    public RaycastHit hit;
    private Ray ray;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !recentlySpawned)
        {
            recentlySpawned = true;
            CheckView();
            StartCoroutine(SpawnDelayer());
        }
    }
    private void CheckView()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5f /*distance*/))
        {
            if (hit.transform.CompareTag("Spawner"))
            {
                switch (hit.transform.name)
                {
                    case "Crate":
                        ManageFood(potato, spawnPointPot);
                        
                        break;
                    case "Crate_1":
                        ManageFood(fish, spawnPointFish);
                       
                        break;
                    case "Crate_2":
                        ManageFood(ham, spawnHam);
                        
                        break;
                    case "Crate_3":
                        ManageFood(spice, spiceSpawn);
                       
                        break;
                }

            }
        }
    }

    private void ManageFood(GameObject prefab,Transform spawnPoint)
    {
        rotX = 0f;
        rotY = 270f;
        rotZ = 0f;
        ViewObject(prefab,spawnPoint, rotX, rotY, rotZ, ray);

    }
    private void ViewObject(GameObject prefab,Transform spawnPoint, float rotX, float rotY, float rotZ, Ray ray)
    {
        Instantiate(prefab, new Vector3(
            spawnPoint.transform.position.x,
            ray.origin.y,
            spawnPoint.transform.position.z),
            Quaternion.Euler(rotX, playerRotationPoint.transform.localRotation.eulerAngles.y + rotY, rotZ)
            );
    }
    IEnumerator SpawnDelayer() // delay 3 second couroutine
    {
        yield return new WaitForSeconds(1);
        recentlySpawned = false;
    }
}