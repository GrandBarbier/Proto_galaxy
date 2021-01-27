using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 4;
    public float jumpHeight = 1.2f;
    public float turnSpeed = 5;

    public bool grounded;

    public LayerMask groundMask;
    public Transform groundCheck;
    public Transform axisPoint;
    
    public GravityCtrl gravityCtrl;
    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityCtrl = GetComponent<GravityCtrl>();
    }
    
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 axis = (axisPoint.position - groundCheck.position);
        
        Debug.DrawLine(transform.position, axis * 50);

        transform.Rotate(axis, x * turnSpeed * Time.deltaTime);
        
        
        transform.Translate(new Vector3(0,0, z) * speed * Time.deltaTime);
        
        Debug.Log(x);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * 10000 * jumpHeight * Time.deltaTime);
        }
        
        grounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
    }
}
