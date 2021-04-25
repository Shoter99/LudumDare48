using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject[] platforms;
    public float elevation = -3.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlatform", 0f, .3f);
    }

    void SpawnPlatform()
    {
        float xCord = Random.Range(-7f, 7f);
        int platformIndex = Random.Range(0, 100);
        if (platformIndex > 75) platformIndex = 1;
        else if (platformIndex < 15) platformIndex = 2;
        else if (platformIndex < 17) platformIndex = 3;
        else platformIndex = 0;
        Instantiate(platforms[platformIndex], new Vector2(xCord, elevation), new Quaternion(0,0,0,0));
        elevation -= 6f;
    }
}
