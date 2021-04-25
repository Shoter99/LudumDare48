using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public Transform player;
    private float startingPoint;
    public static float score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;
    public Image rewind;
    // Start is called before the first frame update
    void Awake()
    { 
        score = 0;
        CoinManager.numOfCoins = 0;
        startingPoint = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        bool rewindUsed = Player.rewindUsed;
        int canRewind = Player.canRewindTime;
        if(!rewindUsed && canRewind == 1)
        {
            rewind.enabled = true;
        }
        else
        {
            rewind.enabled = false;
        }
        coinsText.text = CoinManager.numOfCoins.ToString();
        float points = Mathf.Floor(player.position.y - startingPoint);
        if (score > points) score = points;
        scoreText.text = score.ToString();
    }
}
