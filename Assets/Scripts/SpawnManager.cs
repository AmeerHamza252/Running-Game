using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] coinsPrefabs;
    public GameObject[] coins1Prefabs;
    //public int obstacleIndex;
    public GameObject coins;
    private float spawnSpeed = 1;
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
       // spawnCoins3();
       spawnCoins2();
        spawnCoins1();

    }

    

    void spawnObstacles()// spawn obstacles
    {
        if (timer > spawnSpeed)
        {
            int rand = Random.Range(0, obstaclePrefabs.Length);

            GameObject obs = Instantiate(obstaclePrefabs[rand]);
            obs.transform.position = transform.position + new Vector3(0, 0, -130);
            timer = 0;
        }
        timer += Time.deltaTime;

    }
    void spawnCoins2()//spawn coins
    {
        if (timer > spawnSpeed)
        {
            int rand = Random.Range(0, coinsPrefabs.Length);
            GameObject coin = Instantiate(coinsPrefabs[rand]);
            coin.transform.position = transform.position + new Vector3(0, 0, -130);
            timer = 0;
            Debug.Log("2222");
        }
        timer += Time.deltaTime;

    }
    void spawnCoins1()//spawn coins
    {
        if (timer > spawnSpeed)
        {
            int rand = Random.Range(0, coins1Prefabs.Length);
            GameObject coin = Instantiate(coins1Prefabs[rand]);
            coin.transform.position = transform.position + new Vector3(0, 0, -130);
            timer = 0;
            Debug.Log("1111");

        }
        timer += Time.deltaTime;

    }
    //void spawnCoins3()//spawn coins
    //{
    //    if (timer > spawnSpeed)
    //    {
    //        GameObject coin = Instantiate(coins);
    //        coin.transform.position = transform.position + new Vector3(0, 8, -130);
    //        timer = 0;

    //    }
    //    timer += Time.deltaTime;

    //}
}
