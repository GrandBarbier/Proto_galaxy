using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    public GameObject planet;

    public bool isGrounded;

    public float groundDistance;
    
    private Vector3 groundNormal;
    
    public LayerMask planetMask;
    
    private Vector3 velocity;
    private float gravity = -10;
    
    public float jumpHeight = 1f;
    public float jumpForward = 1f;
    public float jumpRight = 1f;
    
    public float speed = 10;
    public float acceleration;
    public float airControl;
    
    private Rigidbody rb;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, planetMask))
        {
            groundDistance = hit.distance;
            groundNormal = hit.normal;
            
            Debug.DrawLine(transform.position, hit.point, Color.red);
            
            if (groundDistance <= 1.1f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        
        if (isGrounded)
        { 
           
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * 4000 * jumpHeight * Time.deltaTime);
            }
            Debug.Log(x);
            Debug.Log(z);
        }
       
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime);

        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
        
        if (!isGrounded)
        {
            rb.AddForce(gravDirection * gravity);
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform != planet.transform) {
 
            planet = collision.transform.gameObject;
 
            Vector3 gravDirection = (transform.position - planet.transform.position).normalized;
 
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravDirection) * transform.rotation;

            transform.rotation = toRotation;
            
            
 
            rb.velocity = Vector3.zero;
            rb.AddForce(gravDirection * gravity);
        }
    }
}
