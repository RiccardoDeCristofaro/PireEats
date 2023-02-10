using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[DisallowMultipleComponent]
public class SwitchCam : MonoBehaviour
{    
    //cams
    public Camera playerCam;
    public Camera cannonCam;
    //movements
    public CannonMov cannonMov;
    public GameObject player;
    // bool
    private bool changedCam = true;


    private void Start()
    {
       
    }
    private void Update()
    {
        if (changedCam == true && Input.GetKeyDown(KeyCode.E))
        {
            // cannon
            cannonMov.enabled = true;
            cannonCam.gameObject.SetActive(true);

            //player
            playerCam.gameObject.SetActive(false);
            player.SetActive(false);

            changedCam = false;

        }
        else if (!changedCam && Input.GetKeyDown(KeyCode.E))
        {
            ExitCannonCam();
        }
    }
    
    public void ExitCannonCam()
    {
        
        cannonMov.enabled = false;
        cannonCam.gameObject.SetActive(false);

        playerCam.gameObject.SetActive(true);
        player.SetActive(true);
        changedCam = true;

    }

    
}
