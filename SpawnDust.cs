using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDust : MonoBehaviour
{
    public GameObject dust;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Feet")
        {
            Instantiate(dust, transform.position, transform.rotation);
        }
    }
}
