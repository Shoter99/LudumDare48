using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetCoin : MonoBehaviour
{
    public static int coins;
    public TextMeshProUGUI coinText;
    private void Awake()
    {
        RefreshCoins();
    }
    public static void RefreshCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
        GameObject coinText = GameObject.Find("Coins");
        coinText.GetComponent<TextMeshProUGUI>().text = coins.ToString();
    }
}
