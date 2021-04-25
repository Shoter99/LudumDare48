using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnLevelEnd : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EndLevel")
        {
            animator.SetTrigger("EndLevel");
            StartCoroutine("LoadEndLevel");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    IEnumerator LoadEndLevel()
    {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    } 
    
}
