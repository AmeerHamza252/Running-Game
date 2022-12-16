using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject GameOverPanel;
    public GameObject GamePanel;

    public TextMeshProUGUI gameover;
    public TextMeshProUGUI scoreText;
    public GameObject Restartbtn;
    public int coins;
    public int myScore=0;

    public enum GameMode { Easy, Hard }
    public GameMode gameMode = GameMode.Easy;
    private float spawnSpeed = 2;
    public bool IsGameStarted = false;

    public static Action<float> OnGameStart;
    public static Action OnGameOver;

    public static GameManager Instance;

   
    private void Start()
    {
        
        Instance = this;
    }
    public void StartGame(int gamemode)
    {
        IsGameStarted = true;
        switch (gamemode)
        {
            case 0:
                gameMode = GameMode.Easy;
                spawnSpeed = 3;
                break;
            case 1:
                gameMode = GameMode.Hard;
                spawnSpeed = 1;
                break;
            default:
                break;
        }
        StartPanel.SetActive(false);
        GamePanel.SetActive(false);
        OnGameStart?.Invoke(spawnSpeed);
    }
    public void AddScore(int score)// Add Score
    {
        myScore= myScore+score;
        scoreText.text = myScore.ToString();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

   /* private void OnTriggerEnter(Collider Con)//Coins Detect
    {
        if (Con.gameObject.tag == "Coin")
        {
            //coins=coins+1;
            //score=score+1;
            //scoreText.text = score.ToString();
            Con.gameObject.SetActive(false);
            AddScore(5);
            Destroy(Con.gameObject);
            Debug.Log("Coin Collected");

        }
    }*/
    public void GameOver()
    {
        GamePanel.SetActive(true);
        GameOverPanel.SetActive(true);
        OnGameOver?.Invoke();
    }
   
   /* private void OnCollisionEnter(Collision hamza)//Obstacles Detect
    {
        if (hamza.gameObject.tag == "obstacle")
        {
            Destroy(hamza.gameObject);
            //Debug.Log("collision detect");
            Restartbtn.gameObject.SetActive(true);
            gameover.gameObject.SetActive(true);

            //SceneManager.LoadScene("Level1");
        }
    }*/

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
    private void OnApplicationQuit()
    {
        Instance = null;
    }
}
