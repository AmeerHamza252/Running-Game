using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesMovement : MonoBehaviour
{
    private float oSpeed = 80.0f;
    bool isPlaying = true;
    // bool isRunning = false;

    private void OnEnable()
    {
       
        GameManager.OnGameOver += GameOver;
    }



    private void OnDisable()
    {
       
        GameManager.OnGameOver -= GameOver;
    }
    private void GameStart(float spawnSpeed)
    {
        isPlaying = true;

    }
    private void GameOver()
    {
        isPlaying = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//obstacles movement
    {
        if(isPlaying)
        transform.Translate(Vector3.forward*Time.deltaTime*oSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            

        }
    }
   
}
