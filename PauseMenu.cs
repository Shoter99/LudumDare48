using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public Animator transition;
    public GameObject pauseUI;
    float transitionTime = 1;
    // Update is called once per frame
    private void Awake()
    {
        GamePaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused) Resume();
            else Pause();
        }
        if(Input.GetKeyDown(KeyCode.Space) && GamePaused)
        {
            Resume();
        }
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        FindObjectOfType<AudioManager>().Play("Select");
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        FindObjectOfType<AudioManager>().Play("Select");
    }
    public void GoToMainMenu()
    {
        transition.SetTrigger("Start");
        Time.timeScale = 1f;
        StartCoroutine("LoadLevel");
        
        FindObjectOfType<AudioManager>().Play("Select");
        
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0);
        
    }
}
