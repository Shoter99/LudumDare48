using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static bool gameActive = false;
    public float CameraSpeed = 5f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameActive)
        {
            gameActive = true;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Score.score < 1000f) CameraSpeed += .03f* Time.fixedDeltaTime;
        if(gameActive) transform.position = transform.position + new Vector3(0, (-CameraSpeed * Time.fixedDeltaTime) ,0);
    }


}
