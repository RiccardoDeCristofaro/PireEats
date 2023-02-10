using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InfoShip : MonoBehaviour
{
    public string shipNationality;
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.CompareTag(other.name))
        {
            Debug.Log(other.gameObject.name);
        }
    }
}
