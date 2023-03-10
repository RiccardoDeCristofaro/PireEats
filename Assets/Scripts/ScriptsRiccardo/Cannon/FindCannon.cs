using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCannon : MonoBehaviour
{
    public SwitchCam changeCam;
    public CannonFire fireCannon;
    public Button enterButton;
    public Transform whereToPos;
    public PickUpDrop_Simple objectWeLook;

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition); // select whatever the camera is looking

        RaycastHit hit;
       
       
        
        if (Physics.Raycast(cameraRay, out hit, 5f))
        {
            if ((hit.transform.tag == "Cannon") && objectWeLook.grab)               
            {             
                enterButton.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    LoadCannon();                                                         
                    fireCannon.capacity = 1;
                    objectWeLook.grab = false;
                    fireCannon.enabled = true;
                }
                changeCam.enabled = true;
                enterButton.gameObject.SetActive(true);
            }
            else
                enterButton.gameObject.SetActive(false);
               

        }
        else
        {
            changeCam.enabled = false;
            enterButton.gameObject.SetActive(false);
            objectWeLook.grab = true;
            fireCannon.enabled = false;
        }
        
    }
    void LoadCannon()
    {            
        objectWeLook.hitObject.transform.position = whereToPos.position;     
        objectWeLook.hitObject.transform.localRotation = Quaternion.Euler(0, 0, 0);     
        objectWeLook.hitObject.rigidbody.isKinematic = true;
        
        objectWeLook.hitObject.transform.SetParent(whereToPos.transform, true);
        
         
        
        
        
    }
}
