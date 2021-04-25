using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        FindObjectOfType<AudioManager>().Play("Select");
    }
    public void QuitApp()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Select");
        PlayerPrefs.Save();

        Debug.Log("Quit");
    }
}
