using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            CoinManager.numOfCoins++;
            FindObjectOfType<AudioManager>().Play("CoinPickUp");
            PlayerPrefs.SetInt("Coins",  PlayerPrefs.GetInt("Coins" )+ 1);
            Destroy(collision.gameObject); 
        }
    }
}
