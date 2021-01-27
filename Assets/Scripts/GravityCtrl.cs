using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{
    public GravityOrbit gravity;
    private Rigidbody rb;

    public PlayerMovements playerMovements;

    public float rotationSpeed = 20;
    
    public Vector3 gravityUp = Vector3.zero;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravity)
        {
            

            if (gravity.fixedDirection)
            {
                gravityUp = gravity.transform.up;
            }
            else
            {
                gravityUp = (transform.position - gravity.transform.position).normalized;
            }
            
            Vector3 locaUp = transform.up;

            Quaternion targetRotation = Quaternion.FromToRotation(locaUp, gravityUp) * transform.rotation;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            //transform.up = Vector3.Lerp(transform.up, gravityUp, rotationSpeed * Time.deltaTime);
            
            rb.AddForce((-gravityUp * gravity.gravity) * rb.mass);
        } 
    }
}
