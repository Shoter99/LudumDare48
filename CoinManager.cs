using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    public static int numOfCoins;
    public Transform player;
    float numOfSpawningCoins = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", 0f, 3f);
    }
    private void Update()
    {
        numOfSpawningCoins = Mathf.Floor(-Score.score/200);
    }
    void SpawnCoin()
    {
        if (MoveCamera.gameActive)
        {

            float posX = Random.Range(-6, 6);
            float posY = Random.Range(30, 100);

            Instantiate(coin, new Vector2(posX, Score.score - posY), new Quaternion(0, 0, 0, 0));
        }
    }

       void SpawnCoins()
    {
        for (int i = 0; i <= numOfSpawningCoins; i++)
        {
            SpawnCoin();
        }
    }
}
