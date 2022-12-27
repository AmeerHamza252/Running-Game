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

    bool destroyed;
    // Update is called once per frame
    void Update()//obstacles movement
    {
        if(isPlaying)
        transform.Translate(Vector3.forward*Time.deltaTime*oSpeed);
        Vector3 dir = transform.position - Camera.main.transform.position;
        float dot = Vector3.Dot( Camera.main.transform.forward,dir.normalized);
        Debug.Log(dot.ToString());
        if(dot < 0 && !destroyed)
        {
            PoolsManager.Instance.Despawn(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PoolsManager.Instance.Despawn(gameObject);
        }
    }
   
}
