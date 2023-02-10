using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [Tooltip("timer: ")]
    public float timer;
    [Tooltip("cannon ammo")]
    public float capacity = 0;
    [Tooltip(" fire transform:")]
    public Transform FireLauncher;
    // colliders
    public Collider cannonCollider;

    [Tooltip("throw force: ")]
    [SerializeField] public float BallForce = 180f;

    public SwitchCam changeCam;
    public FindCannon objectWeFire;


    private void OnGUI()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Start is called before the first frame update
    void Start()
    {
        cannonCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && capacity == 1)
        {
            Fire();
            objectWeFire.objectWeLook.hitObject.rigidbody.useGravity = true;
            StartCoroutine(FireReset());
        }
    }
    public void Fire()
    {
        // adding force to thrown out the food
        Debug.Log(objectWeFire.objectWeLook.hitObject.rigidbody.name);
        objectWeFire.objectWeLook.hitObject.rigidbody.AddForce(FireLauncher.forward * BallForce, ForceMode.Impulse);


    }
    IEnumerator FireReset()
    {

        Debug.Log("you have fired");
        capacity = 0;
        yield return new WaitForSeconds(3);
        Debug.Log("you have waited 3 seconds");
        Destroy(objectWeFire.objectWeLook.hitObject.transform.gameObject);    
        yield return null;
    }

}
