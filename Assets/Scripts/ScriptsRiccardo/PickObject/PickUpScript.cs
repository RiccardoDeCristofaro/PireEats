using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;
    public GameObject wall;

    [Header("Pickup Settings")]
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 5f; //how far the player can pickup the object from
    [SerializeField] private float pickupForce = 150.0f;// force to move obj
    private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    private GameObject heldObj; //object which we pick up
    private Rigidbody heldObjRb; //rigidbody of object we pick up
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index / name by index

    //Reference to script which includes mouse movement of player (looking around)
    //disable the player looking around when rotating the object.
    // show the UI button to display the infos;
    //public Button button;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("LayerPick"); //Layer name
       
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) //click mouse and left, to pick up
        {
            if (heldObj == null) //if currently not holding anything
            {
                //perform raycast to check if player is looking at object
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    //make sure pickup tag exist
                    if (hit.transform.gameObject.tag == "PickableObj")
                    {
                        //display UI
                      
                        //pass in object hit into the PickUpObject function

                        PickUpObject(hit.transform.gameObject);
                    }
                }
                
                   
            }
            else if(Input.GetMouseButtonDown(0))   
            {
                if (canDrop == true)
                {
                    StopClipping(); //prevents object from clipping through walls
                    DropObject();
                }
            }
        }
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw
            {
                StopClipping();
                ThrowObject();
            }

        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            
            heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true; // the problem is here, how we should resolve 
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer

            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            //make sure object doesnt collide with player
        }
    }
    void DropObject()
    {   // reset the object stats to pick another object
        //enable again the collision with player
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdPos.position) > 0.1f) // return the distance between a start position and final position;
        {
          
            // not working 
            Vector3 moveDirection = (holdPos.position - heldObj.transform.position);
            //keep object position the same as the holdPosition position
            heldObj.transform.position = holdPos.transform.position;
            // something here to allow the cube follow the cam;
            heldObjRb.AddForce(moveDirection * pickupForce);
          
        }
    }   
        void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))//hold R key to rotate
        {
            canDrop = false; //make sure throwing can't occur during rotating



            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else
        {
            // stop rotating , so you can drop
            canDrop = true;
        }
    }
    void ThrowObject()
    {
        //same as drop function, but add force to object to throw
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0;
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }
    void StopClipping() //function only called when dropping/throwing
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position); //distance from holdPos to the camera
        //have to use RaycastAll as object blocks raycast in center screen
        //RaycastAll returns array of all colliders hit within the clip-range
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        //if the array length is greater than 1, meaning it has hit more than just the object we are carrying
        if (hits.Length > 1)
        {
            //change object position to camera position 
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f); //offset slightly downward to stop object dropping above player 
            //if your player is small, change the -0.5f to a smaller number (in magnitude) ie: -0.1f
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool collisionIgnored = true;
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), wall.GetComponent<Collider>(), collisionIgnored);
        

        
    }
}