using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTileMap : MonoBehaviour
{
    public Transform player;
    float startingPoint;
    private void Awake()
    {
        startingPoint = player.position.y + transform.position.y;
    }
    void Update()
    {
        if (player.position.y < startingPoint - 60)
        {
            transform.Translate(new Vector3(0, -90, 0));
            startingPoint = player.position.y + transform.position.y;
        }
    }
}
