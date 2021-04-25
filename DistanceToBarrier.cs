using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DistanceToBarrier : MonoBehaviour
{
    public Transform player;
    public Transform barrier;
    public TextMeshProUGUI distance;
    void Update()
    {
        distance.text = Mathf.Floor(-player.position.y + barrier.position.y).ToString();
    }
}
