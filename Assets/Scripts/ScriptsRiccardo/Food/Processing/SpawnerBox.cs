using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBox : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject ingredient;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(ingredient.gameObject, spawnPoint.position, Quaternion.identity);
        }
    }
}
