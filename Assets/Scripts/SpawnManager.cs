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
    [SerializeField]
    bool isPlaying;
   
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
        this.spawnSpeed = spawnSpeed;
    }
    private void GameOver()
    {
        isPlaying = false;
    }
    void Start()
    {
       
    }
    void Update()
    {
        if (!isPlaying) return;

        spawnObstacles();
        spawnCoins();

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
