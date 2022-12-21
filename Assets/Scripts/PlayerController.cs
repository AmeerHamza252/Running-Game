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
    private int desiredLane = 1;
    private float laneDistance = 8f;

    private Vector3 TargetDirectionPosition;
    enum Lane
    {
        L1,
        L2,
        L3
    }

    Lane currentLane = Lane.L2;

    private void OnEnable()
    {
        GameManager.OnGameStart += GameSpawnerStart;
        GameManager.OnGameOver += GameOver;
    }



    private void OnDisable()
    {
        GameManager.OnGameStart -= GameSpawnerStart;
        GameManager.OnGameOver -= GameOver;
    }
    private void GameSpawnerStart(float spawnSpeed)
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
       // m_Rigidbody = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();//Get Rigidbody
        myAnim = GetComponent<Animator>();//Get Animator
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) return;
        Movement();
        PlayerDirection();


    }
    void PlayerDirection()
    {
        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        Vector3 targetPosition = transform.position.z * transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = targetPosition;*/

        switch (currentLane)
        {
            case Lane.L1: Lane1();break;
            case Lane.L2: Lane2();break;
            case Lane.L3: Lane3();break;
        }
    }

    void Lane1()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Lane.L2;
            TargetDirectionPosition = Vector3.zero;
        }
    }

    void Lane2()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Lane.L3;
            TargetDirectionPosition = transform.right * laneDistance;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Lane.L1;
            TargetDirectionPosition = -transform.right * laneDistance;
        }
    }

    void Lane3()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Lane.L2;
            TargetDirectionPosition = Vector3.zero;
        }
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
            
            GetComponent<CapsuleCollider>().height = 2f ;
            GetComponent<CapsuleCollider>().center = Vector3.up;
            //isSlide = true;
        }
        //if(myAnim.GetCurrentAnimatorClipInfo(0).)
        // m_Rigidbody.MovePosition(transform.position * Time.deltaTime * speed);

    }
    private void FixedUpdate()//player jump
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Debug.Log("Jump");

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           // grounded = true;
            //transform.Translate(Vector3.up * jumpForce);
        }
      if(Vector3.Distance(transform.position, TargetDirectionPosition) > 0.1f)
        {
            Vector3 lerpPoint = Vector3.Lerp(transform.position, TargetDirectionPosition, Time.deltaTime * 5f);
            rb.MovePosition(lerpPoint);
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

    public void SlideEnd()
    {
        GetComponent<CapsuleCollider>().height = 4f;
        GetComponent<CapsuleCollider>().center = Vector3.up * 2;
    }
    // private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "obstacle")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}
