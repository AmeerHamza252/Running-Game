using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int obstacleIndex;
    public GameObject coins;
    private float spawnSpeed = 2;
    private float timer = 0;

    public enum GameMode { Easy, Hard }
    public GameMode gameMode = GameMode.Easy;
    public bool IsGameStarted = false;


     void Start()
    {
       
    }
    void Update()
    {
        spawnObstacles();
        spawnCoins();

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
     }

    void spawnObstacles()// spawn obstacles
    {
        if (timer > spawnSpeed)
        {
            int rand = Random.Range(0, obstaclePrefabs.Length);

            GameObject obs = Instantiate(obstaclePrefabs[rand]);
            obs.transform.position = transform.position + new Vector3(29, 1, -30);
            timer = 0;
        }
        timer += Time.deltaTime;

    }
    void spawnCoins()//spawn coins
    {
        if (timer > spawnSpeed)
        {
            //int rand = Random.Range(0, coins);

            GameObject coin = Instantiate(coins);
            coin.transform.position = transform.position + new Vector3(29, 4, -30);
            timer = 0;

        }
        timer += Time.deltaTime;

    }
}
