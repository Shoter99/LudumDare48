using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Feet")
        {
            StartCoroutine("DestroyPlatform");
        }
    }
    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        FindObjectOfType<AudioManager>().Play("DestroyPlatform");
        StartCoroutine("RestoreDestroyed");
    }
    IEnumerator RestoreDestroyed()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
