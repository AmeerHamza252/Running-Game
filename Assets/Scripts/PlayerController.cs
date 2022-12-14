using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
   public float speed = 0.7f;
    public float gravityScale;
    private GameManager gameManager;
    public bool grounded=false;
    private Animator myAnim;
   
   // bool isRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Get Rigidbody
        myAnim = GetComponent<Animator>();//Get Animator
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Jumping();
    }
    //Vector3 prevPoint;
    void Movement()//Player Movement with Animation
    {
        //float speed = Input.GetAxis("Vertical");
       // Debug.Log(speed);
        myAnim.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.C))
        {
            myAnim.SetTrigger("slide");                 
        }
    }
    private void FixedUpdate()//player jump
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        if (Input.GetKey(KeyCode.Space) && grounded)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //Debug.Log("ajaasaa");
           // grounded = true;
            //transform.Translate(Vector3.up * jumpForce);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    // private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "obstacle")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
