using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public Button djBtn;
    public Button rtBtn;
    public Text djText;
    public Text rtText;

    private void Awake()
    {
        CheckButtons();
       
    }
    public void BuyDoubleJump()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        if(coins >= 250 && PlayerPrefs.GetInt("JumpCount") < 2)
        {
            Player.maxGravityAmmo = 2;
            PlayerPrefs.SetInt("Coins", coins - 250);
            GetCoin.RefreshCoins();
            PlayerPrefs.SetInt("JumpCount", 2);
            CheckButtons();
        }
    }
    public void BuyRewindTime()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        if (coins >= 500 && PlayerPrefs.GetInt("RewindActivated") != 1)
        {
            Player.canRewindTime = 1;
            PlayerPrefs.SetInt("Coins", coins - 500);
            GetCoin.RefreshCoins();
            PlayerPrefs.SetInt("RewindActivated", 1);
            CheckButtons();
        }
    }
    void CheckButtons()
    {
        if (PlayerPrefs.GetInt("JumpCount") >= 2)
        {
            djBtn.interactable = false;
            djText.text = "Bought";
            djText.fontSize = 21;
        }
        if (PlayerPrefs.GetInt("RewindActivated") == 1)
        {
            rtBtn.interactable = false;
            rtText.text = "Bought";
            rtText.fontSize = 21;
        }
    }
}
