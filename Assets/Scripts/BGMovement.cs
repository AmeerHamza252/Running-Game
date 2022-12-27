using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public float bspeed=1f ;
    private Vector3 StartPosition;
    public SpriteRenderer renderer;
   // float totalWidth;
    bool isMoved;
    public enum Hamza { H, A };
    private Hamza hamza = Hamza.H;
    [SerializeField] private char mode;


    void Start()
    {
        StartPosition = transform.position;
        
    }
    
   
    void Update()
    {
     //  if (!isMoved) return;
        BackgroundMovement();
       //HMode(mode);

    }
    public void BackgroundMovement()
    {
        
        transform.Translate(translation: Vector3.forward * bspeed * Time.deltaTime);

        if (transform.position.z > 90f)
        {
            transform.position = renderer.transform.position - Vector3.forward * renderer.bounds.size.z;
        }
    }
    private void OnEnable()
    {
        GameManager.OnGameOver += GameStart;
        GameManager.OnGameOver += GameOver;
    }
    private void HMode(char mode)
    {
        
        isMoved =true;
        switch (mode)
        {
            case 'H':
                hamza = Hamza.H;
                bspeed = 1f;
                //Debug.LogWarning("Hmode");
                break;
            case 'A':
                hamza = Hamza.A;
                bspeed = 50f;
              //  Debug.LogWarning("mode");
                break;
            default: break;



        }


    }



    private void OnDisable()
    {
        GameManager.OnGameOver -= GameStart;
        GameManager.OnGameOver -= GameOver;
    }
    private void GameStart()
    {
        isMoved = false;
        bspeed = 0;
    } 
    private void GameOver()
    {
        isMoved = false;
       bspeed = 0;
    }


}
