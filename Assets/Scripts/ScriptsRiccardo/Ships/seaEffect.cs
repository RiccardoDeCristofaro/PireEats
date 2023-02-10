using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class seaEffect : MonoBehaviour
{
   
    [SerializeField] private float speed = 4.5f;
    private void Start()
    {
        speed = Random.Range(1f, 5f);
    }

    private void FixedUpdate()
    {
        float xRot = Mathf.PingPong((Time.time) / 45 * speed, 1) * 2.5f;
       gameObject.transform.rotation = Quaternion.Euler(xRot, 0, 0);
    }

}
