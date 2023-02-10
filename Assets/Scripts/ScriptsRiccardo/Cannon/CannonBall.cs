using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public Rigidbody foodRigidbody;
    public Transform foodPosition;
    public float BallForce = 1f;
    public Collider foodCollider;
    public Transform FireLauncher;
    private bool canFire;
    
    
    private void OnGUI()
    {
        Cursor.visible = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
        foodRigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canFire)
        { 
            gameObject.transform.SetParent(null);
            foodRigidbody.useGravity = true;
            Fire();         
            StartCoroutine(FireReset());
        }

    }

    public void Fire()
    {
        
            foodRigidbody.AddForce(FireLauncher.forward * BallForce, ForceMode.Impulse);
        // Playercam.gameObject.SetActive(true);

    }
    IEnumerator FireReset()
    {
        canFire = false;
        Debug.Log("you have fired");
        yield return new WaitForSeconds(5);
        Debug.Log("you can fire again now");
        canFire = true;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cannon")
        {
            foodPosition.position = FireLauncher.position;
            foodPosition.transform.SetParent(FireLauncher, true);
            foodRigidbody.freezeRotation = true;
            foodCollider.isTrigger = true;
           
            
        }
    }
}
