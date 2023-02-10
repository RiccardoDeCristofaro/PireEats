using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PickUpDrop : MonoBehaviour
{
    /// <summary>
    /// Add: when camera is moving object follow with same direction, if camera is rotating object don't move.
    /// Mouse movement for object movement: y axis depend on scroll Wheel.
    /// </summary>
    // public
    public static string target;
    public string internalObj;
    public RaycastHit hitObject;
    [Header("Pickup Settings")]
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 5f; //how far the player can pickup the object from

    public GameObject Cammanager;

    // private
    //private Vector3 distance;
    private bool grab = false;
    void Update()
    {
        if (pickUpRange < 0)
            pickUpRange = 0;

        // raycasting
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, pickUpRange) && hit.transform.gameObject.layer == 6)
        {
            target = hit.transform.gameObject.name;
            internalObj = hit.transform.gameObject.name;
            // pickup
            if (Input.GetKeyDown(KeyCode.Mouse0) && !grab)
            {
                hitObject = hit;
                //minDistance = Vector3.Distance(transform.position, hitInfo.transform.position);
                PickUp(hitObject);
              
                   
              
            }
            Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.green);
        }
        else
            Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.red);


        // ray for cannon
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit2, pickUpRange) && hit2.transform.gameObject.layer == 7)
        {
            target = hit2.transform.gameObject.name;
            internalObj = hit2.transform.gameObject.name;
            if (Input.GetKeyDown(KeyCode.Mouse1)) 
            { 
                hitObject = hit2;
                Cammanager.SetActive(true);
            }
            Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.green);
        }
        else
            Debug.DrawRay(transform.position, transform.forward * pickUpRange, Color.red);
    
        if (grab)
        {
            // drop
            if (Input.GetMouseButtonUp(0))
                Drop(hitObject);
            else if (Input.GetKeyDown(KeyCode.L))
                Throw(hitObject);
            // move object
            MoveObject(hitObject);
            //distance = hitInfo.transform.position - transform.position;
            //hitInfo.transform.position = transform.position + 
            //(distance.normalized * Mathf.Clamp(distance.magnitude, minDistance - 0.5f, minDistance + 2f));

            Debug.DrawLine(transform.position, hitObject.transform.position, Color.blue);

            Debug.Log(hitObject.transform.localPosition.magnitude);
        }
    }
    private void MoveObject(RaycastHit hitInfo)
    {
        Vector3 newPosition = hitInfo.transform.localPosition;

        /*
        if (Input.GetKey(KeyCode.A))
            newPosition += Vector3.left * 0.01f;
        if (Input.GetKey(KeyCode.D))
            newPosition += Vector3.right * 0.01f;
        if (Input.GetKey(KeyCode.W))
            newPosition += Vector3.up * 0.01f;
        if (Input.GetKey(KeyCode.S))
            newPosition += Vector3.down * 0.01f;

        ObjectLimit(newPosition);
        */

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            newPosition += Vector3.forward * 0.1f;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            newPosition += Vector3.back * 0.1f;

        ObjectLimit(newPosition);
    }
    private void ObjectLimit(Vector3 newPosition)
    {
        if (newPosition.z > 1f && newPosition.magnitude < 2f)
            hitObject.transform.localPosition = newPosition;
    }
    private bool PickUp(RaycastHit hitInfo)
    {
        grab = true;
        hitInfo.transform.SetParent(transform);
        hitInfo.rigidbody.isKinematic = true;
        Debug.Log(grab);
        return grab;
    }
    private bool Drop(RaycastHit hitInfo)
    {
        grab = false;
        hitInfo.transform.SetParent(null);
        hitInfo.rigidbody.isKinematic = false;
        Debug.Log(grab);
        return grab;
    }
    private bool Throw(RaycastHit hitInfo)
    {
        hitInfo.transform.SetParent(null);
        hitInfo.rigidbody.isKinematic = false;
        Debug.Log(grab);
        hitObject.rigidbody.AddForce(transform.forward * throwForce);

        return grab;
    }
}
