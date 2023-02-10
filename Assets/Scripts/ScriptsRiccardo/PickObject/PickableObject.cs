using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickableObject : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform HoldingArea;
    public GameObject heldObj;
    public Rigidbody heldObjRB;

    [Header("physics Parameters")]
    [SerializeField] private float pickUpRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (heldObj != null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) // normal raycast, directed to the object
                {
                    Debug.Log("see the object");
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
                    // pick up object
                    PickUpObject(hit.transform.gameObject); // pick up the object found by the hit of the raycast ;
                }
                else
                {
                    Debug.Log("WTF");
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                //drop object
               DropObject();
            }
        }
        if (heldObj != null)
        {
            //Move object around in the map
            MoveObject();
        }
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, HoldingArea.position) > 0.1f) // return the distance between a start position and final position;
        {
            Vector3 moveDirection = (HoldingArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
    void PickUpObject(GameObject objectToPick)
    {
        if (objectToPick.GetComponent<Rigidbody>())
        {
            heldObjRB = objectToPick.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation; // set constrainst for every rotations of the pickable object;
            
            heldObjRB.transform.parent = HoldingArea;
            heldObj = objectToPick;
        }
    }
    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None; // set constrainst for every rotations of the pickable object;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
