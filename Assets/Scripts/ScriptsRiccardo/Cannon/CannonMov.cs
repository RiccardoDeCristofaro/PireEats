using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMov : MonoBehaviour
{
   

    [Header("Cam settings")]
    [Tooltip("Min = 10\nMax = 400")]
    public float cameraSensibility;

   
    private float CamRot;

    [Header("range settings")]   
    [Tooltip("Min = 10\nMax = 45")]
    public float motionRange_LeftRight;
   

    
    private float LeftRightNew;

    private void Start()
    {
      
        CamRot = 0f;
    }

    private void Update()
    {
        cameraSensibility = Mathf.Clamp(cameraSensibility, 1, 400);
        motionRange_LeftRight = Mathf.Clamp(motionRange_LeftRight, 1, 90);
      
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // inputs
           
            LeftRightNew = -Input.GetAxisRaw("Mouse X") * cameraSensibility * Time.deltaTime;

            
            CamRot -= LeftRightNew;

            CamRot = Mathf.Clamp(CamRot, -motionRange_LeftRight, motionRange_LeftRight);
         

          //  Player.localRotation = Quaternion.Euler(0f, 0f, PlayRot); // revisionare per capire 
            transform.localRotation = Quaternion.Euler(0f, CamRot, 0f);


            if (Input.GetKeyDown(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
        }


    }

}
