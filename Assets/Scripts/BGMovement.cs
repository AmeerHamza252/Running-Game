using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public float speed = 8f;
    private Vector3 StartPosition;
    public SpriteRenderer renderer;
    float totalWidth;
    bool isMoved;
   
    void Start()
    {
        StartPosition = transform.position;
        Debug.Log(renderer.bounds.size.z, gameObject);
    }

   
    void Update()
    {
     //  if (!isMoved) return;
        BackgroundMovement();
    }
    public void BackgroundMovement()
    {
        
        transform.Translate(translation: Vector3.right * speed * Time.deltaTime);

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



    private void OnDisable()
    {
        GameManager.OnGameOver -= GameStart;
        GameManager.OnGameOver -= GameOver;
    }
    private void GameStart()
    {
        isMoved = true;
    } 
    private void GameOver()
    {
        isMoved = false;
    }


}
