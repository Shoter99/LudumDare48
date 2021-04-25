using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoEffect : MonoBehaviour
{
    public float slowmoDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !PauseMenu.GamePaused)
        {
            Time.timeScale = .6f;
            StartCoroutine("ResetTimeSpeed");
        }
        
    }
    IEnumerator ResetTimeSpeed()
    {
        yield return new WaitForSeconds(slowmoDuration);
        Time.timeScale = 1f;
    }
}
