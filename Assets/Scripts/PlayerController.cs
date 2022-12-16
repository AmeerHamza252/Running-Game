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
    bool isPlaying;
    // bool isRunning = false;

    private void OnEnable()
    {
        GameManager.OnGameStart += GameStart;
        GameManager.OnGameOver += GameOver;
    }



    private void OnDisable()
    {
        GameManager.OnGameStart -= GameStart;
        GameManager.OnGameOver -= GameOver;
    }
    private void GameStart(float spawnSpeed)
    {
        isPlaying = true;
       
    }
    private void GameOver()
    {
        isPlaying = false;
        speed = 0;
        myAnim.SetFloat("Speed", speed);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Get Rigidbody
        myAnim = GetComponent<Animator>();//Get Animator
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) return;
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
    private void OnCollisionEnter(Collision hamza)
    {
        grounded = true;
        if (hamza.gameObject.tag == "obstacle")
        {
            Destroy(hamza.gameObject);
            GameManager.Instance.GameOver();
            //Debug.Log("collision detect");
           /* Restartbtn.gameObject.SetActive(true);
            gameover.gameObject.SetActive(true);*/

            //SceneManager.LoadScene("Level1");
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
    private void OnTriggerEnter(Collider Con)//Coins Detect
    {
        if (Con.gameObject.tag == "Coin")
        {
            //coins=coins+1;
            //score=score+1;
            //scoreText.text = score.ToString();
            Con.gameObject.SetActive(false);
            GameManager.Instance.AddScore(5);
            Destroy(Con.gameObject);
            Debug.Log("Coin Collected");

        }
    }
    // private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "obstacle")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
