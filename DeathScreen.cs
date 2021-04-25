using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public bool deathActive = false;
    public GameObject deathScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;

    public void Death()
    {
        Time.timeScale = 0f;
        highscore.text = "Highscore: "+PlayerPrefs.GetFloat("Highscore").ToString();
        deathScreen.SetActive(true);
        score.text = "Score: "+Score.score.ToString();
        deathActive = true;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && deathActive )
        {
            Restart();
        }
    }
    public void Restart()
    {
        Player.rewindUsed = false;
        MoveCamera.gameActive = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
