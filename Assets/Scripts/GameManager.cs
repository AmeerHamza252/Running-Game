using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameover;
    public TextMeshProUGUI scoreText;
    public GameObject Restartbtn;
    public int coins;
    public int myScore=0;
   
    public void AddScore(int score)// Add Score
    {
        myScore= myScore+score;
        scoreText.text = myScore.ToString();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    private void OnTriggerEnter(Collider Con)//Coins Detect
    {
        if (Con.gameObject.tag=="Coin")
        {
            //coins=coins+1;
            //score=score+1;
            //scoreText.text = score.ToString();
            Con.gameObject.SetActive(false);
            AddScore(5);
            Destroy(Con.gameObject);
            Debug.Log("Coin Collected");
           
        }
    }
    void GameOver()
    {
        gameover.gameObject.SetActive(true);
    }
   
    private void OnCollisionEnter(Collision hamza)//Obstacles Detect
    {
        if (hamza.gameObject.tag == "obstacle")
        {
            Destroy(hamza.gameObject);
            //Debug.Log("collision detect");
            Restartbtn.gameObject.SetActive(true);
            gameover.gameObject.SetActive(true);

            //SceneManager.LoadScene("Level1");
        }
    }

    public void restart()
    {

        SceneManager.LoadScene("Level1");
    }

    //private void OnTriggerEnter(Collider other)
    //{

    //}
    //public GameObject Restartbtn;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag=="Player")
    //    {
    //        Restartbtn.SetActive(true);
    //    }
    //}

}
