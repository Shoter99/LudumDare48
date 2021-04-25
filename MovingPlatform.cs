using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformMovingSpeed = 3f;

    void FixedUpdate()
    {
        transform.Translate(new Vector2(platformMovingSpeed * Time.fixedDeltaTime, 0));
        if(transform.position.x <= -7 || transform.position.x >= 7)
        {
            platformMovingSpeed = -platformMovingSpeed;
        }
    }



}
